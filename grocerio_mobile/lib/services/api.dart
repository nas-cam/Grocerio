import 'dart:io';
import 'dart:convert';
import 'dart:convert' as convert;
import 'package:http/http.dart' as http;
import 'package:grocerio_mobile/models/logged_user.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';

class ApiService {
  static var _storage = FlutterSecureStorage();
  static const BASE_URL = 'http://d16ed204fddc.ngrok.io/api/';

  static _generateAuthHeader(String username, String password) {
    String credentials = '${username}:${password}';
    Codec<String, String> stringToBase64 = utf8.fuse(base64);
    String encoded = stringToBase64.encode(credentials);

    return {
      HttpHeaders.authorizationHeader: 'Basic ${encoded}',
      HttpHeaders.contentTypeHeader: 'application/json'
    };
  }

  static Future<LoggedUser> login(String username, String password) async {
    try {
      var response = await http.get(Uri.parse('${BASE_URL}Login/${username}'),
          headers: ApiService._generateAuthHeader(username, password));

      if (response.statusCode == 200) {
        var jsonResponse = convert.jsonDecode(response.body);
        LoggedUser retrievedUser = new LoggedUser.fromJson(jsonResponse);

        _storage.write(key: 'username', value: retrievedUser.username);
        _storage.write(key: 'role', value: retrievedUser.role.toString());
        _storage.write(key: 'roleName', value: retrievedUser.roleName);
        _storage.write(key: 'id', value: retrievedUser.id.toString());
        _storage.write(
            key: 'accountId', value: retrievedUser.accountId.toString());
        _storage.write(key: 'password', value: password);

        return Future.value(retrievedUser);
      } else {
        throw Exception('An error occurred while authenticating!');
      }
    } catch (e) {
      print(e.toString());
    }

    throw Exception('An error occurred while authenticating!');
  }

  static Future<dynamic> getUser() async {
    try {
      var userId = await _storage.read(key: 'id');

      var response = await http.get(
          Uri.parse('${BASE_URL}Users/GetUserById/${userId}'),
          headers: _generateAuthHeader(
              (await _storage.read(key: 'username')).toString(),
              (await _storage.read(key: 'password')).toString()));

      if (response.statusCode == 200) {
        var jsonResponse = convert.jsonDecode(response.body);

        return Future.value(jsonResponse);
      } else {
        throw Exception('An error occurred while getting user!');
      }
    } catch (e) {
      print(e.toString());
    }

  }

  static Future<dynamic> getStores() async {
    var accountId = await _storage.read(key: 'accountId');

    try {
      var reqBody = {'accountId': int.parse(accountId!), 'searchTerm': ''};

      var response = await http.post(
          Uri.parse('${BASE_URL}Stores/ReceiveStores'),
          headers: _generateAuthHeader(
              (await _storage.read(key: 'username')).toString(),
              (await _storage.read(key: 'password')).toString()),
          body: convert.jsonEncode(reqBody));

      if (response.statusCode == 200) {
        var jsonResponse = convert.jsonDecode(response.body);

        return Future.value(jsonResponse);
      } else {
        throw Exception('An error occurred while trying to get stores!');
      }
    } catch (e) {
      print(e);
    }
  }

  static Future<dynamic> getStoreProducts(int storeId) async {
    var accountId = await _storage.read(key: 'accountId');

    try {
      var reqBody = {
        'accountId': int.parse(accountId!),
        'storeId': storeId,
        'searchTerm': '',
        "cetgoryIds": [],
        "types": []
      };

      var response = await http.post(
          Uri.parse('${BASE_URL}Stores/ReceiveStoreProducts'),
          headers: _generateAuthHeader(
              (await _storage.read(key: 'username')).toString(),
              (await _storage.read(key: 'password')).toString()),
          body: convert.jsonEncode(reqBody));

      if (response.statusCode == 200) {
        var jsonResponse = convert.jsonDecode(response.body);

        return Future.value(jsonResponse);
      } else {
        throw Exception('An error occurred while trying to get store products!');
      }
    } catch (e) {
      print(e);
    }
  }

  static Future<dynamic> checkout(
      dynamic cartItems, dynamic creditCardId) async {
    var userId = await _storage.read(key: 'id');
    try {
      for (var i = 0; i < cartItems.length; i++) {
        var response = await http.post(
            Uri.parse(
                '${BASE_URL}ShoppingCarts/AddItem/${userId}/${cartItems[i]['product']['storeProductId']}/${cartItems[i]['quantity']}'),
            headers: _generateAuthHeader(
                (await _storage.read(key: 'username')).toString(),
                (await _storage.read(key: 'password')).toString()),
            body: convert.jsonEncode({}));
      }
    } catch (e) {
      return Future.value(false);
    }

    try {
      var response = await http.post(
          Uri.parse('${BASE_URL}ShoppingCarts/Checkout/${userId}/${creditCardId}'),
          headers: _generateAuthHeader(
              (await _storage.read(key: 'username')).toString(),
              (await _storage.read(key: 'password')).toString()),
          body: convert.jsonEncode({}));

      return Future.value(true);
    } catch (e) {
      return Future.value(false);
    }
  }

  static Future<dynamic> register(
      String firstName,
      String lastName,
      String username,
      String password,
      String city,
      String cardHolder,
      String cardNumber,
      String expiration,
      String cvv) async {
    try {
      var reqBody = {
        'firstName': firstName,
        'lastName': lastName,
        'username': username,
        'password': password,
        'confirmPassword': password,
        'city': city,
        'mainCreditCard': {
          'cardHolder': cardHolder,
          'cardNumber': cardNumber,
          'expiration': expiration,
          'cvv': cvv
        }
      };

      var response = await http.post(Uri.parse('${BASE_URL}Users'),
          headers: {HttpHeaders.contentTypeHeader: 'application/json'},
          body: convert.jsonEncode(reqBody));

      if (response.statusCode == 200) {
        var jsonResponse = convert.jsonDecode(response.body);

        return Future.value(jsonResponse);
      } else {
        throw Exception('An error occurred while trying to register!');
      }
    } catch (e) {
      print(e);
    }
  }

  static Future<dynamic> updateUser(
    String firstName,
    String lastName,
    String username,
    String email,
    String city,
    String address,
  ) async {
    var userId = await _storage.read(key: 'id');

    try {
      var reqBody = {
        'firstName': firstName,
        'lastName': lastName,
        'username': username,
        'mail': email,
        'city': city,
        'address': address
      };

      var response = await http.put(
          Uri.parse('${BASE_URL}Users/UpdateUser/${userId}'),
          headers: _generateAuthHeader(
              (await _storage.read(key: 'username')).toString(),
              (await _storage.read(key: 'password')).toString()),
          body: convert.jsonEncode(reqBody));

      if (response.statusCode == 200) {
        var jsonResponse = convert.jsonDecode(response.body);

        return Future.value(jsonResponse);
      } else {

        throw Exception('An error occurred while trying to register!');
      }
    } catch (e) {
      print(e);
    }
  }

  static Future<dynamic> updateCreditCard(
    int cardId,
    String cardHolder,
    String cardNumber,
    String expiration,
    String cvv,
  ) async {
    var userId = await _storage.read(key: 'id');

    try {
      var reqBody = {
        'cardHolder': cardHolder,
        'cardNumber': cardNumber,
        'expiration': expiration,
        'cvv': cvv,
      };

      var response = await http.post(
          Uri.parse('${BASE_URL}Cards/UpdateCreditCard/${userId}/${cardId}'),
          headers: _generateAuthHeader(
              (await _storage.read(key: 'username')).toString(),
              (await _storage.read(key: 'password')).toString()),
          body: convert.jsonEncode(reqBody));

      if (response.statusCode == 200) {
        var jsonResponse = convert.jsonDecode(response.body);

        return Future.value(jsonResponse);
      } else {

        throw Exception(
            'An error occurred while trying to update main credit card!');
      }
    } catch (e) {
      print(e);
    }
  }

  static Future<dynamic> createNewCreditCard(
      String cardHolder,
      String cardNumber,
      String expiration,
      String cvv,
      ) async {
    var userId = await _storage.read(key: 'id');

    try {
      var reqBody = {
        "cardHolder": cardHolder,
        "cardNumber": cardNumber,
        "expiration": expiration,
        "cvv": cvv,
      };

      print(reqBody);

       var response = await http.post(
          Uri.parse('${BASE_URL}Cards/AddNewCreditCard/${userId}'),
          headers: _generateAuthHeader(
              (await _storage.read(key: 'username')).toString(),
              (await _storage.read(key: 'password')).toString()),
          body: convert.jsonEncode(reqBody));

      print(response);

      if (response.statusCode == 200) {
        var jsonResponse = convert.jsonDecode(response.body);

        return Future.value(jsonResponse);
      } else {
        throw Exception(
            'An error occurred while trying to create new credit card!');
      }
    } catch (e) {
      print(e);
    }
  }

  static Future<dynamic> getCreditCards() async {
    try {
      var userId = await _storage.read(key: 'id');

      var response = await http.get(
          Uri.parse('${BASE_URL}Cards/GetUsersCreditCards/${userId}'),
          headers: _generateAuthHeader(
              (await _storage.read(key: 'username')).toString(),
              (await _storage.read(key: 'password')).toString()));

      if (response.statusCode == 200) {
        var jsonResponse = convert.jsonDecode(response.body);

        return Future.value(jsonResponse);
      } else {
        throw Exception('An error occurred while getting credit cards!');
      }
    } catch (e) {
      print(e.toString());
    }

  }

  static Future<dynamic> getTrackingItems() async {
    try {
      var userId = await _storage.read(key: 'id');

      var response = await http.get(
          Uri.parse('${BASE_URL}Purchase/GetTrackingItems/${userId}'),
          headers: _generateAuthHeader(
              (await _storage.read(key: 'username')).toString(),
              (await _storage.read(key: 'password')).toString()));

      if (response.statusCode == 200) {
        var jsonResponse = convert.jsonDecode(response.body);

        return Future.value(jsonResponse);
      } else {
        throw Exception('An error occurred while getting tracking items!');
      }
    } catch (e) {
      print(e.toString());
    }

  }

  static Future<dynamic> refundTrackingItem(int trackingItemId) async {
    var userId = await _storage.read(key: 'id');

    try {

      var response = await http.post(
          Uri.parse('${BASE_URL}Purchase/RefundTrackingItem/${userId}/${trackingItemId}'),
          headers: _generateAuthHeader(
              (await _storage.read(key: 'username')).toString(),
              (await _storage.read(key: 'password')).toString()));

      if (response.statusCode == 200) {
        var jsonResponse = convert.jsonDecode(response.body);

        return Future.value(jsonResponse);
      } else {
        throw Exception('An error occurred while trying to refund item!');
      }
    } catch (e) {
      print(e);
    }
  }

  static Future<dynamic> getNotifications() async {
    try {
      var accountId = await _storage.read(key: 'accountId');

      var response = await http.get(
          Uri.parse('${BASE_URL}Notifications/${accountId}'),
          headers: _generateAuthHeader(
              (await _storage.read(key: 'username')).toString(),
              (await _storage.read(key: 'password')).toString()));

      if (response.statusCode == 200) {
        var jsonResponse = convert.jsonDecode(response.body);

        return Future.value(jsonResponse);
      } else {
        throw Exception('An error occurred while getting notifications!');
      }
    } catch (e) {
      print(e.toString());
    }

  }

  static Future<dynamic> removeNotification(int notificationId) async {
    try {
      var accountId = await _storage.read(key: 'accountId');

      var response = await http.get(
          Uri.parse('${BASE_URL}Notifications/ClearNotification/${notificationId}/${accountId}'),
          headers: _generateAuthHeader(
              (await _storage.read(key: 'username')).toString(),
              (await _storage.read(key: 'password')).toString()));

      if (response.statusCode == 200) {
        var jsonResponse = convert.jsonDecode(response.body);

        return Future.value(jsonResponse);
      } else {
        throw Exception('An error occurred while removing notification!');
      }
    } catch (e) {
      print(e.toString());
    }

  }

  static Future<dynamic> getPurchasedItems() async {
    try {
      var userId = await _storage.read(key: 'id');

      var response = await http.get(
          Uri.parse('${BASE_URL}Purchase/GetPurchasedItems/${userId}'),
          headers: _generateAuthHeader(
              (await _storage.read(key: 'username')).toString(),
              (await _storage.read(key: 'password')).toString()));

      if (response.statusCode == 200) {
        var jsonResponse = convert.jsonDecode(response.body);

        return Future.value(jsonResponse);
      } else {
        throw Exception('An error occurred while getting tracking items!');
      }
    } catch (e) {
      print(e.toString());
    }

  }

  static Future<dynamic> getReturnReasons() async {
    try {

      var response = await http.get(
          Uri.parse('${BASE_URL}ReturnReasons'),
          headers: _generateAuthHeader(
              (await _storage.read(key: 'username')).toString(),
              (await _storage.read(key: 'password')).toString()));

      if (response.statusCode == 200) {
        var jsonResponse = convert.jsonDecode(response.body);

        return Future.value(jsonResponse);
      } else {
        throw Exception('An error occurred while getting return reasons!');
      }
    } catch (e) {
      print(e.toString());
    }

  }

  static Future<dynamic> returnPurchasedItem(int purchasedItemId, int returnReasonId) async {
    var userId = await _storage.read(key: 'id');

    try {

      var response = await http.post(
          Uri.parse('${BASE_URL}Purchase/ReturnPurchasedItem/${userId}/${purchasedItemId}/${returnReasonId}'),
          headers: _generateAuthHeader(
              (await _storage.read(key: 'username')).toString(),
              (await _storage.read(key: 'password')).toString()));

      if (response.statusCode == 200) {
        var jsonResponse = convert.jsonDecode(response.body);

        return Future.value(jsonResponse);
      } else {
        throw Exception('An error occurred while trying to return item!');
      }
    } catch (e) {
      print(e);
    }
  }


}


