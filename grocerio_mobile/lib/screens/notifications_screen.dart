import 'package:flutter/material.dart';
import 'package:grocerio_mobile/services/api.dart';
import 'package:grocerio_mobile/utils/toaster_service.dart';
import '../constants/app_colors.dart' as AppColors;

class NotificationsScreen extends StatefulWidget {
  const NotificationsScreen({Key? key}) : super(key: key);

  @override
  _NotificationsScreenState createState() => _NotificationsScreenState();
}

class _NotificationsScreenState extends State<NotificationsScreen> {
  var notifications = [];

  void getNotifications() async {
    try {
      var result = await ApiService.getNotifications();
      if (result != null) {
        setState(() {
          this.notifications = result;
        });
      }

    } catch (e) {
      ToasterService.showToast(
          'error', 'An error occurred while getting notifications!');
    }
  }

  void removeNotification(int notificationId, int index) async {
    try {
      await ApiService.removeNotification(notificationId);

      setState(() {
        this.notifications = List.from(this.notifications)
          ..removeAt(index);
      });

      ToasterService.showToast(
          'success', 'Successfully removed the notification!');
    } catch (e) {
      ToasterService.showToast(
          'error', 'An error occurred while getting notifications!');
    }
  }

  @override
  void initState() {
    super.initState();
    this.getNotifications();
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
                    'NOTIFICATIONS',
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
                  margin: EdgeInsets.only(top: 270, bottom: 50.0),
                  child: ListView.builder(
                    itemCount: this.notifications.length,
                    itemBuilder: (context, index) {
                      if (notifications.length > 0)
                        return Container(
                          key: ObjectKey(index),
                          margin: EdgeInsets.only(
                            top: 10,
                            bottom: 10,
                          ),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.spaceBetween,
                            children: [
                              Container(
                                padding: EdgeInsets.only(
                                    bottom: 20.0, left: 20.0, right: 20.0),
                                width: MediaQuery.of(context).size.width * 0.8,
                                child: Text(
                                  this.notifications[index]['message'],
                                  style: TextStyle(
                                      color: Colors.black,
                                      decoration: TextDecoration.none,
                                      fontSize: 15,
                                      fontFamily: 'Roboto',
                                      fontWeight: FontWeight.normal),
                                ),
                              ),
                              Padding(
                                padding: EdgeInsets.only(
                                    bottom: 20.0, left: 20.0, right: 20.0),
                                child: GestureDetector(
                                  onTap: () => this.removeNotification(this.notifications[index]['id'], index),
                                  child: Icon(
                                    Icons.delete,
                                    color: AppColors.MAIN_COLOR,
                                  ),
                                ),
                              )
                            ],
                          ),
                        );
                      else
                        return Padding(
                          padding: EdgeInsets.only(
                              bottom: 20.0, left: 20.0, right: 20.0),
                          child: Text(
                            'No notifications',
                            style: TextStyle(
                                color: Colors.black,
                                decoration: TextDecoration.none,
                                fontSize: 20,
                                fontFamily: 'Roboto',
                                fontWeight: FontWeight.normal),
                          ),
                        );
                    },
                  )),
            ),
          ],
        ),
      ),
    ));
  }
}
