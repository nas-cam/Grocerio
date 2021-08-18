import 'package:flutter/cupertino.dart';

class GrocerioProvider extends ChangeNotifier {
  static List<dynamic> cart_items = [];

  getItems() {
    return cart_items;
  }

  addItemToCart(dynamic item) {
    bool itemExists = false;

    for (var i = 0; i < cart_items.length; i++) {
      if (cart_items[i]['product']['product']['id'] ==
          item['product']['product']['id']) {
        itemExists = true;
        break;
      }
    }

    if (itemExists == true) {
      for (var i = 0; i < cart_items.length; i++) {
        if (cart_items[i]['product']['id'] == item['product']['id']) {
          cart_items[i]['quantity'] += 1;
          break;
        }
      }
    } else {
      cart_items.add(item);
    }

    notifyListeners();
  }

  removeItemFromCart(dynamic item) {
    for (var i = 0; i < cart_items.length; i++) {
      if (cart_items[i]['product']['product']['id'] ==
              item['product']['product']['id'] &&
          cart_items[i]['quantity'] > 1) {
        cart_items[i]['quantity'] -= 1;
        notifyListeners();
        return;
      } else if (cart_items[i]['product']['product']['id'] ==
              item['product']['product']['id'] &&
          cart_items[i]['quantity'] == 1) {
        cart_items.removeWhere((element) =>
            element['product']['product']['id'] ==
            item['product']['product']['id']);
        notifyListeners();
        return;
      }
    }
  }

  resetCart() {
    cart_items = [];
    notifyListeners();
  }
}
