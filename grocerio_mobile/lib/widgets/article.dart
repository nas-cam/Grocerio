import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../constants/app_colors.dart' as AppColors;
import 'package:grocerio_mobile/utils/toaster_service.dart';
import 'package:grocerio_mobile/providers/main_provider.dart';

class ArticleWidget extends StatefulWidget {
  final String id;
  final String title;
  String description;
  String price;
  String imgUrl;
  dynamic product;

  ArticleWidget(
      {this.id = '',
      this.title = '',
      this.description = '',
      this.price = '',
      this.imgUrl = '',
      this.product = null});

  @override
  _ArticleWidgetState createState() => _ArticleWidgetState(
      articleId: this.id,
      articleTitle: this.title,
      articleDescription: this.description,
      articlePrice: this.price,
      articleimgUrl: this.imgUrl,
      articleProduct: this.product);
}

class _ArticleWidgetState extends State<ArticleWidget> {
  String articleId;
  String articleTitle;
  String articleDescription;
  String articlePrice;
  String articleimgUrl;
  dynamic articleProduct;

  _ArticleWidgetState(
      {this.articleId = '',
      this.articleTitle = '',
      this.articleDescription = '',
      this.articlePrice = '',
      this.articleimgUrl = '',
      this.articleProduct});

  void addItemToCart() {
    var productObj = {
      'quantity': 1,
      'product': this.articleProduct,
    };

    context.read<GrocerioProvider>().addItemToCart(productObj);
    ToasterService.showToast('success', 'Item added to cart successfully!');
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.only(left: 13),
      width: (MediaQuery.of(context).size.width * 0.5) - 30,
      height: 250,
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
      child: Column(
        children: [
          Row(
            mainAxisAlignment: MainAxisAlignment.end,
            children: [
              Container(
                padding: EdgeInsets.all(7),
                margin: EdgeInsets.all(7),
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
                  borderRadius: BorderRadius.all(Radius.circular(20)),
                ),
                child: GestureDetector(
                  onTap: this.addItemToCart,
                  child: Icon(
                    Icons.add_shopping_cart,
                    color: AppColors.MAIN_COLOR,
                  ),
                ),
              ),
            ],
          ),
          Image.network(
            this.articleimgUrl,
            width: 100,
            height: 75,
          ),
          Text(
            this.articleTitle,
            style: TextStyle(
                color: Colors.grey[700],
                fontSize: 12,
                decoration: TextDecoration.none,
                fontFamily: 'Roboto'),
          ),
          Text(
            this.articleDescription,
            style: TextStyle(
                color: Colors.grey[500],
                fontSize: 12,
                decoration: TextDecoration.none,
                fontFamily: 'Roboto'),
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.end,
            children: [
              Container(
                padding: EdgeInsets.all(5),
                margin: EdgeInsets.only(right: 10),
                child: Text(
                  '${this.articlePrice} KM',
                  style: TextStyle(
                      color: Colors.grey[700],
                      fontSize: 20,
                      decoration: TextDecoration.none,
                      fontFamily: 'Roboto'),
                ),
              ),
            ],
          )
        ],
      ),
    );
  }
}
