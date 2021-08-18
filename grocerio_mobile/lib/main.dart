import 'package:flutter/material.dart';
import 'package:grocerio_mobile/providers/main_provider.dart';
import 'package:grocerio_mobile/screens/articles_screen.dart';
import 'package:grocerio_mobile/screens/log_in_screen.dart';
import 'package:grocerio_mobile/screens/profile_screen.dart';
import 'package:grocerio_mobile/screens/shopping_cart_screen.dart';
import 'package:provider/provider.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatefulWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  _MyAppState createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> {
  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        ChangeNotifierProvider.value(
          value: GrocerioProvider(),
        ),
      ],
      child: MaterialApp(
        title: 'Grocerio',
        theme: ThemeData(
          primarySwatch: Colors.blue,
        ),
        home: SafeArea(
          child: LoginScreen(),
        ),
      ),
    );
  }
}
