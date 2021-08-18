import 'package:flutter/material.dart';
import 'package:grocerio_mobile/widgets/tracking_item.dart';
import 'package:provider/provider.dart';
import 'package:grocerio_mobile/services/api.dart';
import 'package:grocerio_mobile/widgets/cart_item.dart';
import '../constants/app_colors.dart' as AppColors;
import 'package:grocerio_mobile/utils/toaster_service.dart';
import 'package:grocerio_mobile/providers/main_provider.dart';

class ShoppingCartScreen extends StatefulWidget {
  const ShoppingCartScreen({Key? key}) : super(key: key);

  @override
  _ShoppingCartScreenState createState() => _ShoppingCartScreenState();
}

class _ShoppingCartScreenState extends State<ShoppingCartScreen> {
  dynamic user;
  var cartItems;
  var trackingItems = [];
  var purchasedItems = [];
  List<DropdownMenuItem> cardsDropdownItems = [];
  List<DropdownMenuItem> reasonsDropdownItems = [];
  int? selectedCardId;
  final _cardKey = GlobalKey<FormState>();

  void loadCartItems() {
    this.cartItems = context.read<GrocerioProvider>().getItems();
  }

  void getUser() async {
    try {
      this.user = await ApiService.getUser();
    } catch (e) {
      ToasterService.showToast(
          'error', 'An error occurred while getting the user!');
    }
  }

  void getCreditCards() async {
    try {
      var creditCards = await ApiService.getCreditCards();

      for (int i = 0; i < creditCards.length; i++) {
        this.cardsDropdownItems.add(
          DropdownMenuItem<String>(
            value: creditCards[i]['cardId'].toString(),
            child: Text(creditCards[i]['cardNumber']),
          ),
        );
      }
    } catch (e) {
      ToasterService.showToast(
          'error', 'An error occurred while getting the cards!');
    }
  }

  void getTrackingItems() async {
    try {
      var result = await ApiService.getTrackingItems();
      if(result!=null){
        setState(() {
          this.trackingItems = result;
        });
      }
    } catch (e) {
      print(e);
      ToasterService.showToast(
          'error', 'An error occurred while getting the tracking items!');
    }
  }

  void getPurchasedItems() async {
    try {
      var result = await ApiService.getPurchasedItems();
      if(result!=null){
        setState(() {
          this.purchasedItems = result;
        });
      }
    } catch (e) {
      print(e);
      ToasterService.showToast(
          'error', 'An error occurred while getting the purchased items!');
    }
  }

  void getReturnReasons() async {
    try {
      var returnReasons = await ApiService.getReturnReasons();

      for (int i = 0; i < returnReasons.length; i++) {
        this.reasonsDropdownItems.add(
          DropdownMenuItem<String>(
            value: returnReasons[i]['id'].toString(),
            child: Text(returnReasons[i]['reason']),
          ),
        );
      }
    } catch (e) {
      ToasterService.showToast(
          'error', 'An error occurred while getting the reasons!');
    }
  }


  @override
  void initState() {
    super.initState();
    this.loadCartItems();
    this.getUser();
    this.getCreditCards();
    this.getTrackingItems();
    this.getPurchasedItems();
    this.getReturnReasons();
  }

  void decrementQuantity(dynamic cartItem) {
    try {
      context.read<GrocerioProvider>().removeItemFromCart(cartItem);

      this.setState(() {});
    } catch (e) {
      print(e);
      ToasterService.showToast(
          'error', 'An error occurred while removing item to cart!');
    }
  }

  Future<void> checkout() async {
    try {
      await ApiService.checkout(context.read<GrocerioProvider>().getItems(),
          selectedCardId);

      ToasterService.showToast('success', 'You have successfully checked out!');

      setState(() {
        this.cartItems = [];
      });

      getTrackingItems();

      context.read<GrocerioProvider>().resetCart();
    } catch (e) {
      ToasterService.showToast(
          'error', 'An error occurred while trying to checkout!');
    }
  }

  Future<void> refundTrackingItem(int trackingItemId, int index) async {
    try {
      await ApiService.refundTrackingItem(trackingItemId);

      setState(() {
        this.trackingItems = List.from(this.trackingItems)
          ..removeAt(index);
      });

      ToasterService.showToast('success', 'You have successfully refund the item!');
    } catch (e) {
      ToasterService.showToast(
          'error', 'An error occurred while trying to refund the item!');
    }
  }

  Future<void> returnPurchasedItem(int purchasedItemId,int reasonId, int index) async {
    try {
      await ApiService.returnPurchasedItem(purchasedItemId, reasonId);

      setState(() {
        this.purchasedItems = List.from(this.purchasedItems)
          ..removeAt(index);
      });

      ToasterService.showToast('success', 'You have successfully returned the item!');
    } catch (e) {
      ToasterService.showToast(
          'error', 'An error occurred while trying to return the item!');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
        color: Colors.white,
      ),
      child: DefaultTabController(
        length: 3,
        child: Scaffold(
          appBar: TabBar(
            labelColor: AppColors.MAIN_COLOR,
            labelPadding: EdgeInsets.only(top: 40.0, bottom: 10.0),
            tabs: [
              Tab(icon: Icon(Icons.shopping_cart)),
              Tab(icon: Icon(Icons.airport_shuttle)),
              Tab(icon: Icon(Icons.checklist)),
            ],
          ),
          body: TabBarView(
            children: [
              SingleChildScrollView(
                child: Stack(
                  clipBehavior: Clip.hardEdge,
                  children: [
                    Positioned(
                      top: -200,
                      left: 10,
                      child: Container(
                        padding: EdgeInsets.only(top: 250),
                        height: 450,
                        width: 450,
                        decoration: BoxDecoration(
                          color: AppColors.MAIN_COLOR,
                          borderRadius: BorderRadius.all(
                            Radius.circular(300),
                          ),
                        ),
                      ),
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Container(
                          margin: EdgeInsets.only(top: 40),
                          child: Text(
                            'SHOPPING CART',
                            style: TextStyle(
                                color: Colors.white,
                                decoration: TextDecoration.none,
                                fontSize: 30,
                                fontFamily: 'Roboto',
                                fontWeight: FontWeight.normal),
                          ),
                        ),
                      ],
                    ),
                    SizedBox(
                      height: MediaQuery.of(context).size.height * 1,
                      child: Container(
                          margin: EdgeInsets.only(top: 270, bottom: 150),
                          child: ListView.builder(
                            key: Key(this.cartItems.length.toString()),
                            itemCount: this.cartItems.length + 1,
                            itemBuilder: (context, index) {
                              if (index == this.cartItems.length && index != 0)
                                return Column(
                                  children: [
                                    SizedBox(
                                      height: 20,
                                    ),
                                    Row(
                                      mainAxisAlignment:
                                          MainAxisAlignment.center,
                                      children: [
                                        ElevatedButton(
                                          style: ButtonStyle(
                                            backgroundColor:
                                                MaterialStateProperty.all(
                                                    AppColors.MAIN_COLOR),
                                            shape: MaterialStateProperty.all<
                                                RoundedRectangleBorder>(
                                              RoundedRectangleBorder(
                                                borderRadius:
                                                    BorderRadius.circular(40.0),
                                              ),
                                            ),
                                          ),
                                          onPressed: () => showDialog<String>(
                                            context: context,
                                            builder: (BuildContext context) =>
                                                AlertDialog(
                                              title: const Text(
                                                  'Choose credit card'),
                                              content: DropdownButtonFormField(
                                                key: _cardKey,
                                                hint:
                                                    Text('Choose credit card'),
                                                items: cardsDropdownItems,
                                                onChanged:
                                                    (dynamic newValue) async {
                                                      this.selectedCardId = int.parse(newValue);
                                                    },
                                                decoration: InputDecoration(
                                                  border: OutlineInputBorder(
                                                    borderSide: BorderSide(
                                                        color: Colors.grey),
                                                    borderRadius:
                                                        BorderRadius.circular(
                                                            4.0),
                                                  ),
                                                  contentPadding:
                                                      EdgeInsets.all(12),
                                                  filled: true,
                                                  fillColor: Colors.grey[50],
                                                ),
                                              ),
                                              actions: <Widget>[
                                                TextButton(
                                                  onPressed: () =>
                                                      Navigator.pop(
                                                          context, 'Cancel'),
                                                  child: const Text('Cancel'),
                                                ),
                                                TextButton(
                                                  onPressed: () async => {
                                                    await this.checkout(),
                                                    Navigator.pop(
                                                        context, 'Confirm'),
                                                  },
                                                  child: const Text('Confirm'),
                                                ),
                                              ],
                                            ),
                                          ),
                                          child: Padding(
                                            padding: const EdgeInsets.all(20.0),
                                            child: Text(
                                              'CHECKOUT',
                                              style: TextStyle(
                                                  color: Colors.white,
                                                  fontSize: 21),
                                            ),
                                          ),
                                        ),
                                      ],
                                    ),
                                  ],
                                );
                              else if (this.cartItems.length > 0)
                                return Container(
                                  key: ObjectKey(index),
                                  margin: EdgeInsets.only(
                                    top: 10,
                                    bottom: 10,
                                  ),
                                  child: Row(
                                    children: [
                                      CartItem(
                                        cartItem: this.cartItems[index],
                                        decrementFunction:
                                            this.decrementQuantity,
                                        key: ObjectKey(index),
                                      ),
                                    ],
                                  ),
                                );
                              else
                                return SizedBox.shrink();
                            },
                          )),
                    ),
                  ],
                ),
              ),
              SingleChildScrollView(
                child: Stack(
                  clipBehavior: Clip.hardEdge,
                  children: [
                    Positioned(
                      top: -200,
                      left: 10,
                      child: Container(
                        padding: EdgeInsets.only(top: 250),
                        height: 450,
                        width: 450,
                        decoration: BoxDecoration(
                          color: AppColors.MAIN_COLOR,
                          borderRadius: BorderRadius.all(
                            Radius.circular(300),
                          ),
                        ),
                      ),
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Container(
                          margin: EdgeInsets.only(top: 40),
                          child: Text(
                            'TRACKING ITEMS',
                            style: TextStyle(
                                color: Colors.white,
                                decoration: TextDecoration.none,
                                fontSize: 30,
                                fontFamily: 'Roboto',
                                fontWeight: FontWeight.normal),
                          ),
                        ),
                      ],
                    ),
                    SizedBox(
                      height: MediaQuery.of(context).size.height * 1,
                      child: Container(
                          margin: EdgeInsets.only(top: 270, bottom: 150),
                          child: ListView.builder(
                            key: Key(this.trackingItems.length.toString()),
                            itemCount: this.trackingItems.length + 1,
                            itemBuilder: (context, index) {
                              if (index == this.trackingItems.length && index != 0)
                                return Column(
                                  children: [
                                    SizedBox(
                                      height: 20,
                                    ),
                                  ],
                                );
                              else if (this.trackingItems.length > 0)
                                return Container(
                                  key: ObjectKey(index),
                                  margin: EdgeInsets.only(
                                    top: 10,
                                    bottom: 10,
                                  ),
                                  child: Row(
                                    children: [
                                      TrackingItem(
                                        trackingItem: this.trackingItems[index],
                                        itemIndex: index,
                                        returnFunction: this.refundTrackingItem,
                                        key: ObjectKey(index),
                                      ),
                                    ],
                                  ),
                                );
                              else
                                return SizedBox.shrink();
                            },
                          )),
                    ),
                  ],
                ),
              ),
              SingleChildScrollView(
                child: Stack(
                  clipBehavior: Clip.hardEdge,
                  children: [
                    Positioned(
                      top: -200,
                      left: 10,
                      child: Container(
                        padding: EdgeInsets.only(top: 250),
                        height: 450,
                        width: 450,
                        decoration: BoxDecoration(
                          color: AppColors.MAIN_COLOR,
                          borderRadius: BorderRadius.all(
                            Radius.circular(300),
                          ),
                        ),
                      ),
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Container(
                          margin: EdgeInsets.only(top: 40),
                          child: Text(
                            'PURCHASED ITEMS',
                            style: TextStyle(
                                color: Colors.white,
                                decoration: TextDecoration.none,
                                fontSize: 30,
                                fontFamily: 'Roboto',
                                fontWeight: FontWeight.normal),
                          ),
                        ),
                      ],
                    ),
                    SizedBox(
                      height: MediaQuery.of(context).size.height * 1,
                      child: Container(
                          margin: EdgeInsets.only(top: 270, bottom: 150),
                          child: ListView.builder(
                            key: Key(this.purchasedItems.length.toString()),
                            itemCount: this.purchasedItems.length + 1,
                            itemBuilder: (context, index) {
                              if (index == this.purchasedItems.length && index != 0)
                                return Column(
                                  children: [
                                    SizedBox(
                                      height: 20,
                                    ),
                                  ],
                                );
                              else if (this.purchasedItems.length > 0)
                                return Container(
                                  key: ObjectKey(index),
                                  margin: EdgeInsets.only(
                                    top: 10,
                                    bottom: 10,
                                  ),
                                  child: Row(
                                    children: [
                                      TrackingItem(
                                        trackingItem: this.purchasedItems[index],
                                        itemIndex: index,
                                        returnFunction: this.returnPurchasedItem,
                                        isPurchased: true,
                                        reasonsDropdownItems: this.reasonsDropdownItems,
                                        key: ObjectKey(index),
                                      ),
                                    ],
                                  ),
                                );
                              else
                                return SizedBox.shrink();
                            },
                          )),
                    ),
                  ],
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}
