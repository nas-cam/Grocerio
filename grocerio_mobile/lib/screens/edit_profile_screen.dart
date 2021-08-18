import 'package:flutter/material.dart';
import 'package:grocerio_mobile/services/api.dart';
import 'package:grocerio_mobile/utils/toaster_service.dart';
import '../constants/app_colors.dart' as AppColors;

class EditProfileScreen extends StatefulWidget {
  const EditProfileScreen({Key? key}) : super(key: key);

  @override
  _EditProfileScreenState createState() => _EditProfileScreenState();
}

class _EditProfileScreenState extends State<EditProfileScreen> {
  dynamic user;
  final _formKey = GlobalKey<FormState>();

  final firstNameController = TextEditingController();
  final lastNameController = TextEditingController();
  final usernameController = TextEditingController();
  final emailController = TextEditingController();
  final cityController = TextEditingController();
  final addressController = TextEditingController();

  void getUser() async {
    try {
      this.user = await ApiService.getUser();

      this.firstNameController.text = this.user['firstName'];
      this.lastNameController.text = this.user['lastName'];
      this.usernameController.text = this.user['account']['username'];
      this.cityController.text = this.user['city'];
      this.emailController.text = this.user['mail'];
      this.addressController.text = this.user['address'];

    } catch (e) {
      ToasterService.showToast(
          'error', 'An error occurred while getting the user!');
    }
  }

  Future<void> updateUser() async {
    try {
      await ApiService.updateUser(
        this.firstNameController.text,
        this.lastNameController.text,
        this.usernameController.text,
        this.emailController.text,
        this.cityController.text,
        this.addressController.text,
      );

      ToasterService.showToast('success', 'User updated successfully!');
      Navigator.pop(context);
    } catch (e) {
      ToasterService.showToast(
          'error', 'An error occurred while updating the user!');
    }
  }

  @override
  void initState() {
    super.initState();
    this.getUser();
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
                      'Edit account',
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
                          controller: this.emailController,
                          obscuringCharacter: '*',
                          decoration: InputDecoration(
                            hintText: 'Email',
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
                          controller: this.addressController,
                          decoration: InputDecoration(
                            hintText: 'Address',
                            border: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.grey),
                              borderRadius: BorderRadius.circular(30.0),
                            ),
                          ),
                        ),
                        SizedBox(
                          height: 10,
                        ),
                        Padding(
                          padding: const EdgeInsets.only(top: 10.0),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: [
                              ButtonTheme(
                                minWidth: 400,
                                height: 100,
                                child: Padding(
                                  padding: const EdgeInsets.only(bottom: 20.0),
                                  child: ElevatedButton(
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
                                    onPressed: this.updateUser,
                                    child: Padding(
                                      padding: const EdgeInsets.all(20.0),
                                      child: Text(
                                        'SAVE',
                                        style: TextStyle(
                                            color: Colors.white, fontSize: 21),
                                      ),
                                    ),
                                  ),
                                ),
                              ),
                            ],
                          ),
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
