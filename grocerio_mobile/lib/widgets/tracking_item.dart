import 'package:flutter/material.dart';
import '../constants/app_colors.dart' as AppColors;

class TrackingItem extends StatefulWidget {
  final dynamic trackingItem;
  final dynamic returnFunction;
  final dynamic itemIndex;
  final dynamic isPurchased;
  final dynamic reasonsDropdownItems;

  const TrackingItem(
      {Key? key,
      this.trackingItem,
      this.returnFunction,
      this.itemIndex,
      this.isPurchased,
      this.reasonsDropdownItems})
      : super(key: key);

  @override
  _TrackingItemState createState() => _TrackingItemState(
      trackingItem: this.trackingItem,
      returnFunction: this.returnFunction,
      itemIndex: this.itemIndex,
      isPurchased: this.isPurchased,
      reasonsDropdownItems: this.reasonsDropdownItems);
}

class _TrackingItemState extends State<TrackingItem> {
  dynamic trackingItem;
  dynamic returnFunction;
  dynamic itemIndex;
  dynamic isPurchased;
  dynamic reasonsDropdownItems;
  final _reasonKey = GlobalKey<FormState>();
  int? selectedReasonId;

  _TrackingItemState(
      {this.trackingItem,
      this.returnFunction,
      this.itemIndex,
      this.isPurchased,
      this.reasonsDropdownItems});

  @override
  void initState() {
    super.initState();
  }

  void removeItem() {
    if(this.isPurchased == true){
      this.returnFunction(this.trackingItem['id'], selectedReasonId, itemIndex);
    }else{
      this.returnFunction(this.trackingItem['id'], itemIndex);
    }
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
            this.trackingItem['productImage'],
            width: 80,
          ),
          Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                this.trackingItem != null
                    ? this.trackingItem['product']
                    : 'N/A',
                textAlign: TextAlign.left,
                style: TextStyle(color: Colors.grey[700], fontSize: 20),
              ),
              Text(
                this.trackingItem != null
                    ? this.trackingItem['productDescription']
                    : 'N/A',
                textAlign: TextAlign.left,
                style: TextStyle(color: Colors.grey[500], fontSize: 15),
              ),
              this.isPurchased!=true ?
              Text(
                this.trackingItem != null
                    ? 'Days left: '+this.trackingItem['daysLeft'].toString()
                    : '',
                textAlign: TextAlign.left,
                style: TextStyle(color: Colors.grey[500], fontSize: 15),
              ) : Container(),
              this.isPurchased!=true ?
              Text(
                this.trackingItem != null
                    ? 'Location: '+this.trackingItem['currentLocation']
                    : '',
                textAlign: TextAlign.left,
                style: TextStyle(color: Colors.grey[500], fontSize: 15),
              ) : Container(),
              Container(
                margin: EdgeInsets.only(top: 20),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.end,
                  children: [
                    Container(
                      padding: EdgeInsets.all(2),
                      margin: EdgeInsets.only(right: 10),
                      child: Text(
                        this.trackingItem != null
                            ? '${this.trackingItem['price'].toString()} KM'
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
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: [
                              GestureDetector(
                                onTap: isPurchased != true
                                    ? this.removeItem
                                    : () => showDialog<String>(
                                          context: context,
                                          builder: (BuildContext context) =>
                                              AlertDialog(
                                            title: const Text(
                                                'Choose return reason'),
                                            content: DropdownButtonFormField(
                                              key: _reasonKey,
                                              hint: Text('Choose return reason'),
                                              items: this.reasonsDropdownItems,
                                              onChanged:
                                                  (dynamic newValue) async {
                                                this.selectedReasonId =
                                                    int.parse(newValue);
                                              },
                                              decoration: InputDecoration(
                                                border: OutlineInputBorder(
                                                  borderSide: BorderSide(
                                                      color: Colors.grey),
                                                  borderRadius:
                                                      BorderRadius.circular(
                                                          4.0),
                                                ),
                                                contentPadding:
                                                    EdgeInsets.all(12),
                                                filled: true,
                                                fillColor: Colors.grey[50],
                                              ),
                                            ),
                                            actions: <Widget>[
                                              TextButton(
                                                onPressed: () => Navigator.pop(
                                                    context, 'Cancel'),
                                                child: const Text('Cancel'),
                                              ),
                                              TextButton(
                                                onPressed: () => {
                                                  this.removeItem(),
                                                  Navigator.pop(
                                                      context, 'Confirm'),
                                                },
                                                child: const Text('Confirm'),
                                              ),
                                            ],
                                          ),
                                        ),
                                child: Text(
                                  this.isPurchased == true
                                      ? 'Return'
                                      : 'Cancel',
                                  style: TextStyle(
                                      color: Colors.white, fontSize: 18),
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
