import 'package:flutter/material.dart';
import 'package:grocerio_mobile/services/api.dart';
import '../constants/app_colors.dart' as AppColors;
import 'package:grocerio_mobile/utils/toaster_service.dart';
import 'package:grocerio_mobile/screens/log_in_screen.dart';

class SignUpScreen extends StatefulWidget {
  const SignUpScreen({Key? key}) : super(key: key);

  @override
  _SignUpScreenState createState() => _SignUpScreenState();
}

class _SignUpScreenState extends State<SignUpScreen> {
  final _formKey = GlobalKey<FormState>();

  final firstNameController = TextEditingController();
  final lastNameController = TextEditingController();
  final usernameController = TextEditingController();
  final passwordController = TextEditingController();
  final cityController = TextEditingController();
  final cardHolderController = TextEditingController();
  final cardNumberController = TextEditingController();
  final expirationController = TextEditingController();
  final cvvController = TextEditingController();

  resetForm() {
    this.firstNameController.clear();
    this.lastNameController.clear();
    this.usernameController.clear();
    this.passwordController.clear();
    this.cityController.clear();
    this.cardHolderController.clear();
    this.cardNumberController.clear();
    this.expirationController.clear();
    this.cvvController.clear();
  }

  Future<void> register() async {
    try {
      await ApiService.register(
        this.firstNameController.text.toString(),
        this.lastNameController.text.toString(),
        this.usernameController.text.toString(),
        this.passwordController.text.toString(),
        this.cityController.text.toString(),
        this.cardHolderController.text.toString(),
        this.cardNumberController.text.toString(),
        this.expirationController.text.toString(),
        this.cvvController.text.toString(),
      );

      ToasterService.showToast('success', 'You have successfully registered!');

      this.resetForm();
      Navigator.push(
        context,
        MaterialPageRoute(
          builder: (context) => LoginScreen(),
        ),
      );
    } catch (e) {
      ToasterService.showToast(
          'error', 'An error occurred while trying to register user!');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
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
                  padding: EdgeInsets.only(top: 100),
                  height: 450,
                  width: 450,
                  decoration: BoxDecoration(
                    color: AppColors.MAIN_COLOR,
                    borderRadius: BorderRadius.all(
                      Radius.circular(300),
                    ),
                  ),
                  child: Icon(
                    Icons.supervised_user_circle_rounded,
                    color: Colors.white,
                    size: 120,
                  ),
                ),
              ),
              Container(
                margin: EdgeInsets.only(top: 150),
                padding: EdgeInsets.only(left: 10, right: 10),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    SizedBox(
                      height: 100,
                    ),
                    Text(
                      'Create account',
                      style: TextStyle(
                          color: AppColors.MAIN_COLOR,
                          decoration: TextDecoration.none,
                          fontSize: 30,
                          fontFamily: 'Roboto',
                          fontWeight: FontWeight.normal),
                    ),
                    SizedBox(
                      height: 10,
                    ),
                    Form(
                      key: _formKey,
                      child: Column(children: <Widget>[
                        TextFormField(
                          controller: this.firstNameController,
                          decoration: InputDecoration(
                            hintText: 'First name',
                            border: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.grey),
                              borderRadius: BorderRadius.circular(30.0),
                            ),
                          ),
                        ),
                        SizedBox(
                          height: 10,
                        ),
                        TextFormField(
                          controller: this.lastNameController,
                          decoration: InputDecoration(
                            hintText: 'Last name',
                            border: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.grey),
                              borderRadius: BorderRadius.circular(30.0),
                            ),
                          ),
                        ),
                        SizedBox(
                          height: 10,
                        ),
                        TextFormField(
                          controller: this.usernameController,
                          decoration: InputDecoration(
                            hintText: 'Username',
                            border: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.grey),
                              borderRadius: BorderRadius.circular(30.0),
                            ),
                          ),
                        ),
                        SizedBox(
                          height: 10,
                        ),
                        TextFormField(
                          obscureText: true,
                          controller: this.passwordController,
                          obscuringCharacter: '*',
                          decoration: InputDecoration(
                            hintText: 'Password',
                            border: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.grey),
                              borderRadius: BorderRadius.circular(30.0),
                            ),
                          ),
                        ),
                        SizedBox(
                          height: 10,
                        ),
                        TextFormField(
                          controller: this.cityController,
                          decoration: InputDecoration(
                            hintText: 'City',
                            border: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.grey),
                              borderRadius: BorderRadius.circular(30.0),
                            ),
                          ),
                        ),
                        SizedBox(
                          height: 10,
                        ),
                        TextFormField(
                          controller: this.cardHolderController,
                          decoration: InputDecoration(
                            hintText: 'Card holder',
                            border: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.grey),
                              borderRadius: BorderRadius.circular(30.0),
                            ),
                          ),
                        ),
                        SizedBox(
                          height: 10,
                        ),
                        TextFormField(
                          controller: this.cardNumberController,
                          decoration: InputDecoration(
                            hintText: 'Card number',
                            border: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.grey),
                              borderRadius: BorderRadius.circular(30.0),
                            ),
                          ),
                        ),
                        SizedBox(
                          height: 10,
                        ),
                        TextFormField(
                          obscureText: true,
                          controller: this.expirationController,
                          decoration: InputDecoration(
                            hintText: 'Expiration MM/YY',
                            border: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.grey),
                              borderRadius: BorderRadius.circular(30.0),
                            ),
                          ),
                        ),
                        SizedBox(
                          height: 10,
                        ),
                        TextFormField(
                          obscureText: true,
                          controller: this.cvvController,
                          decoration: InputDecoration(
                            hintText: 'CVV',
                            border: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.grey),
                              borderRadius: BorderRadius.circular(30.0),
                            ),
                          ),
                        ),
                        Padding(
                          padding: const EdgeInsets.only(top: 20.0, bottom: 20.0),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: [
                              ButtonTheme(
                                minWidth: 400,
                                height: 100,
                                child: ElevatedButton(
                                  style: ButtonStyle(
                                    backgroundColor: MaterialStateProperty.all(
                                        AppColors.MAIN_COLOR),
                                    shape: MaterialStateProperty.all<
                                        RoundedRectangleBorder>(
                                      RoundedRectangleBorder(
                                        borderRadius:
                                            BorderRadius.circular(40.0),
                                      ),
                                    ),
                                  ),
                                  onPressed: () async {
                                    await this.register();
                                  },
                                  child: Padding(
                                    padding: const EdgeInsets.all(20.0),
                                    child: Text(
                                      'SIGN UP',
                                      style: TextStyle(
                                          color: Colors.white, fontSize: 21),
                                    ),
                                  ),
                                ),
                              ),
                            ],
                          ),
                        ),
                        Padding(
                          padding: const EdgeInsets.only(top: 10.0, bottom: 20.0),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: [
                              GestureDetector(
                                onTap: () {
                                  Navigator.push(
                                    context,
                                    MaterialPageRoute(
                                      builder: (context) => LoginScreen(),
                                    ),
                                  );
                                },
                                child: Text(
                                  'ALREADY HAVE AN ACCOUNT? \n LOG IN!',
                                  textAlign: TextAlign.center,
                                  style: TextStyle(
                                    color: AppColors.MAIN_COLOR,
                                    fontSize: 20,
                                  ),
                                ),
                              ),
                            ],
                          )
                        ),
                      ]),
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
