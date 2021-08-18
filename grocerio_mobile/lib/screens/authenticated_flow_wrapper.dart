import 'package:flutter/material.dart';
import 'package:grocerio_mobile/screens/edit_credit_card_screen.dart';
import 'package:grocerio_mobile/screens/profile_screen.dart';
import 'package:grocerio_mobile/screens/shopping_cart_screen.dart';
import 'package:grocerio_mobile/screens/notifications_screen.dart';

import 'articles_screen.dart';

class AutheticatedFlowWrapper extends StatefulWidget {
  const AutheticatedFlowWrapper({Key? key}) : super(key: key);

  @override
  _AutheticatedFlowWrapperState createState() =>
      _AutheticatedFlowWrapperState();
}

class _AutheticatedFlowWrapperState extends State<AutheticatedFlowWrapper> {
  var _currentIndex = 0;

  List<Widget> appScreens = [
    ArticlesScreen(),
    EditCreditCard(),
    ShoppingCartScreen(),
    ProfileScreen(),
    NotificationsScreen(),
  ];

  navigateToScreen(index) {
    setState(() {
      this._currentIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        bottomNavigationBar: BottomNavigationBar(
          onTap: this.navigateToScreen,
          type: BottomNavigationBarType.fixed,
          currentIndex: this._currentIndex, // new
          items: [
            new BottomNavigationBarItem(
              icon: Icon(Icons.home),
              title: Text('Home'),
            ),
            new BottomNavigationBarItem(
              icon: Icon(Icons.credit_card),
              title: Text('Payments'),
            ),
            new BottomNavigationBarItem(
                icon: Icon(Icons.local_grocery_store), title: Text('Cart')),
            new BottomNavigationBarItem(
                icon: Icon(Icons.person), title: Text('Profile')),
            new BottomNavigationBarItem(
                icon: Icon(Icons.circle_notifications), title: Text('Activity')),
          ],
        ),
        body: this.appScreens[this._currentIndex]);
  }
}
