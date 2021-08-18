import 'package:flutter/material.dart';
import 'package:grocerio_mobile/services/api.dart';
import '../constants/app_colors.dart' as AppColors;
import 'package:grocerio_mobile/utils/toaster_service.dart';
import 'package:grocerio_mobile/screens/sign_up_screen.dart';
import 'package:grocerio_mobile/screens/authenticated_flow_wrapper.dart';

class LoginScreen extends StatefulWidget {
  const LoginScreen({Key? key}) : super(key: key);

  @override
  _LoginScreenState createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final _formKey = GlobalKey<FormState>();

  final usernameController = TextEditingController();
  final passwordController = TextEditingController();

  _login() async {
    try {
      await ApiService.login(usernameController.text, passwordController.text);

      Navigator.push(
        context,
        MaterialPageRoute(
          builder: (context) => AutheticatedFlowWrapper(),
        ),
      );
    } catch (e) {
      ToasterService.showToast(
          'error', 'An error occurred while trying to log you in!');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        height: MediaQuery.of(context).size.height,
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
                  padding: EdgeInsets.only(top: 150),
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
                margin: EdgeInsets.only(top: 200),
                padding: EdgeInsets.only(left: 10, right: 10),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    SizedBox(
                      height: 100,
                    ),
                    Text(
                      'Log in to your account',
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
                      child: SingleChildScrollView(
                        child: Column(children: <Widget>[
                          TextFormField(
                            controller: this.usernameController,
                            decoration: InputDecoration(
                              hintText: 'example',
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
                            decoration: InputDecoration(
                              hintText: '*******',
                              border: OutlineInputBorder(
                                borderSide: BorderSide(color: Colors.grey),
                                borderRadius: BorderRadius.circular(30.0),
                              ),
                            ),
                          ),
                          SizedBox(
                            height: 20,
                          ),
                          Row(
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
                                    if (_formKey.currentState!.validate()) {
                                      await this._login();
                                    }
                                  },
                                  child: Padding(
                                    padding: const EdgeInsets.all(20.0),
                                    child: Text(
                                      'LOG IN',
                                      style: TextStyle(
                                          color: Colors.white, fontSize: 21),
                                    ),
                                  ),
                                ),
                              ),
                            ],
                          ),
                          SizedBox(
                            height: 50,
                          ),
                          Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: [
                              GestureDetector(
                                onTap: () {
                                  Navigator.push(
                                    context,
                                    MaterialPageRoute(
                                      builder: (context) => SignUpScreen(),
                                    ),
                                  );
                                },
                                child: Text(
                                  'DON\'T HAVE AN ACCOUNT? \nSIGN UP HERE!',
                                  textAlign: TextAlign.center,
                                  style: TextStyle(
                                    color: AppColors.MAIN_COLOR,
                                    fontSize: 20,
                                  ),
                                ),
                              ),
                            ],
                          )
                        ]),
                      ),
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
