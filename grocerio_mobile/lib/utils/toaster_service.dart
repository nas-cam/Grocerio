import 'package:flutter/material.dart';
import 'package:fluttertoast/fluttertoast.dart';

class ToasterService {
  static void showToast(String toastType, String message) {
    Fluttertoast.showToast(
        msg: message,
        toastLength: Toast.LENGTH_SHORT,
        gravity: ToastGravity.BOTTOM,
        timeInSecForIosWeb: 1,
        backgroundColor: toastType == 'error' ? Colors.red : Colors.green,
        textColor: Colors.white,
        fontSize: 16.0);
  }
}
