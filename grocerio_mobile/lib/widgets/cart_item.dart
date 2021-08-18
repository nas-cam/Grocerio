import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../constants/app_colors.dart' as AppColors;
import 'package:grocerio_mobile/utils/toaster_service.dart';
import 'package:grocerio_mobile/providers/main_provider.dart';

class CartItem extends StatefulWidget {
  final dynamic cartItem;
  final dynamic decrementFunction;
  const CartItem({Key? key, this.cartItem, this.decrementFunction})
      : super(key: key);

  @override
  _CartItemState createState() => _CartItemState(
      cartItem: this.cartItem, decrementFunction: this.decrementFunction);
}

class _CartItemState extends State<CartItem> {
  dynamic cartItem;
  dynamic decrementFunction;

  _CartItemState({this.cartItem, this.decrementFunction});

  @override
  void initState() {
    super.initState();
  }

  void incrementQuantity() {
    try {
      context.read<GrocerioProvider>().addItemToCart(cartItem);

      this.setState(() {});
    } catch (e) {
      print(e);
      ToasterService.showToast(
          'error', 'An error occurred while adding item to cart!');
    }
  }

  void removeItem() {
    this.decrementFunction(this.cartItem);
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.only(left: 13),
      width: (MediaQuery.of(context).size.width) - 30,
      height: 150,
      decoration: BoxDecoration(
        color: Colors.white,
        boxShadow: [
          BoxShadow(
            color: Colors.grey.withOpacity(0.5),
            spreadRadius: 5,
            blurRadius: 7,
            offset: Offset(0, 3), // changes position of shadow
          ),
        ],
        borderRadius: BorderRadius.all(Radius.circular(10)),
      ),
      child: Row(
        crossAxisAlignment: CrossAxisAlignment.center,
        mainAxisAlignment: MainAxisAlignment.spaceAround,
        children: [
          Image.network(
            this.cartItem['product']['product']['imageLink'],
            width: 80,
          ),
          Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                this.cartItem != null
                    ? this.cartItem['product']['product']['name']
                    : 'N/A',
                textAlign: TextAlign.left,
                style: TextStyle(color: Colors.grey[700], fontSize: 20),
              ),
              Text(
                this.cartItem != null
                    ? this.cartItem['product']['product']['description']
                    : 'N/A',
                textAlign: TextAlign.left,
                style: TextStyle(color: Colors.grey[500], fontSize: 15),
              ),
              Container(
                margin: EdgeInsets.only(top: 20),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.end,
                  children: [
                    Container(
                      padding: EdgeInsets.all(2),
                      margin: EdgeInsets.only(right: 10),
                      child: Text(
                        this.cartItem != null
                            ? '${this.cartItem['product']['price'].toString()} KM'
                            : 'N/A',
                        style: TextStyle(color: Colors.grey[700], fontSize: 20),
                      ),
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.end,
                      children: [
                        Container(
                          padding: EdgeInsets.only(left: 5, right: 5),
                          height: 30,
                          width: 100,
                          decoration: BoxDecoration(
                            color: AppColors.MAIN_COLOR,
                            borderRadius: BorderRadius.all(
                              Radius.circular(20),
                            ),
                          ),
                          child: Row(
                            crossAxisAlignment: CrossAxisAlignment.center,
                            mainAxisAlignment: MainAxisAlignment.spaceBetween,
                            children: [
                              GestureDetector(
                                onTap: this.incrementQuantity,
                                child: Icon(
                                  Icons.add,
                                  color: Colors.white,
                                ),
                              ),
                              Text(
                                this.cartItem != null
                                    ? '${this.cartItem['quantity'].toString()}'
                                    : 'N/A',
                                style: TextStyle(
                                    color: Colors.white, fontSize: 25),
                              ),
                              GestureDetector(
                                onTap: this.removeItem,
                                child: Icon(
                                  Icons.remove_outlined,
                                  color: Colors.white,
                                ),
                              ),
                            ],
                          ),
                        )
                      ],
                    )
                  ],
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }
}
