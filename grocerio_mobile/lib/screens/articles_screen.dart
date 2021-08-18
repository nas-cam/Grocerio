import 'package:flutter/material.dart';
import 'package:grocerio_mobile/services/api.dart';
import 'package:grocerio_mobile/utils/toaster_service.dart';
import 'package:grocerio_mobile/widgets/article.dart';
import '../constants/app_colors.dart' as AppColors;

class ArticlesScreen extends StatefulWidget {
  const ArticlesScreen({Key? key}) : super(key: key);

  @override
  _ArticlesScreenState createState() => _ArticlesScreenState();
}

class _ArticlesScreenState extends State<ArticlesScreen> {
  var products;
  int? selectedStoreId;
  List<DropdownMenuItem> storesDropdownItems = [];

  final _shopKey = GlobalKey<FormState>();
  final usernameController = TextEditingController();
  final passwordController = TextEditingController();

  @override
  void initState() {
    getStores();
    super.initState();
  }

  Future<void> getStores() async {
    try {
      var getStoresRes = await ApiService.getStores();

      for (var i = 0; i < getStoresRes.length; i++) {
        this.storesDropdownItems.add(
              DropdownMenuItem<String>(
                value: getStoresRes[i]['id'].toString(),
                child: Text(getStoresRes[i]['name']),
              ),
            );
      }
      setState(() {
        this.selectedStoreId = getStoresRes[0]['id'];
      });
      this.getStoreProducts();
    } catch (e) {
      ToasterService.showToast(
          'error', 'An error occurred while trying to get stores!');
    }
  }

  Future<void> getStoreProducts() async {
    try {
      this.products = [];
      this.setState(() {});
      this.products = await ApiService.getStoreProducts(this.selectedStoreId!);
      setState(() {});
    } catch (e) {
      ToasterService.showToast(
          'error', 'An error occurred while trying to get products!');
    }
  }

  List<Widget> getProductsItems() {
    List<Widget> items = [];
    if (this.products != null) {
      for (var i = 0; i < this.products.length; i++) {
        items.add(
          Container(
            margin: EdgeInsets.only(
              top: 0,
              bottom: 10,
              right: 10.0
            ),
            child: ArticleWidget(
              id: this.products[i]['product']['id'].toString(),
              description: this.products[i]['product']['description'],
              imgUrl: this.products[i]['product']['imageLink'],
              price: this.products[i]['price'].toString(),
              title: this.products[i]['product']['name'],
              product: this.products[i],
            ),
          ),
        );
      }

      return items;
    }
    return [];
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
        color: Colors.white,
      ),
      child: SingleChildScrollView(
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
                    'SEARCH',
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
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Container(
                  margin: EdgeInsets.only(top: 100),
                  width: 300,
                  child: Material(
                    elevation: 20.0,
                    borderRadius: BorderRadius.circular(30.0),
                    shadowColor: Colors.grey,
                    child: Container(
                      width: 300,
                      child: DropdownButtonFormField(
                        key: _shopKey,
                        hint: Text('Choose store'),
                        items: storesDropdownItems,
                        onChanged: (dynamic newValue) async {
                          this.selectedStoreId = int.parse(newValue);
                          await this.getStoreProducts();
                        },
                        decoration: InputDecoration(
                          border: OutlineInputBorder(
                            borderSide: BorderSide(color: Colors.grey),
                            borderRadius: BorderRadius.circular(4.0),
                          ),
                          contentPadding: EdgeInsets.all(12),
                          filled: true,
                          fillColor: Colors.grey[50],
                        ),
                      ),
                    ),
                  ),
                ),
              ],
            ),
            SizedBox(
              height: MediaQuery.of(context).size.height * 1,
              child: Container(
                margin: EdgeInsets.only(top: 270, bottom: 80),
                child: GridView.count(
                  childAspectRatio: .9,
                  crossAxisCount: 2,
                  children: this.getProductsItems(),
                ),
              ),
            )
          ],
        ),
      ),
    );
  }
}
