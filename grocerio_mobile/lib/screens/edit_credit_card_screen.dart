import 'package:flutter/material.dart';
import 'package:grocerio_mobile/services/api.dart';
import 'package:grocerio_mobile/utils/toaster_service.dart';
import '../constants/app_colors.dart' as AppColors;

class EditCreditCard extends StatefulWidget {
  const EditCreditCard({Key? key}) : super(key: key);

  @override
  _EditCreditCardState createState() => _EditCreditCardState();
}

class CardItem {
  CardItem(
      {required this.cardId,
      required this.cardHolder,
      required this.cardNumber,
      required this.expiration,
      required this.cvv});

  int cardId;
  String cardHolder;
  String cardNumber;
  String expiration;
  String cvv;
}

class _EditCreditCardState extends State<EditCreditCard> {
  dynamic user;
  List<CardItem> cardsData = [];
  int? selectedCardId;
  List<DropdownMenuItem> cardsDropdownItems = [];
  final _formKey = GlobalKey<FormState>();
  final _updateKey = GlobalKey<FormState>();
  final _createKey = GlobalKey<FormState>();
  final _cardKey = GlobalKey<FormState>();

  final mainCardHolderController = TextEditingController();
  final mainCardNumberController = TextEditingController();
  final mainExpirationController = TextEditingController();
  final mainCVVController = TextEditingController();

  final updateCardHolderController = TextEditingController();
  final updateCardNumberController = TextEditingController();
  final updateExpirationController = TextEditingController();
  final updateCVVController = TextEditingController();

  final createCardHolderController = TextEditingController();
  final createCardNumberController = TextEditingController();
  final createExpirationController = TextEditingController();
  final createCVVController = TextEditingController();

  void getUser() async {
    try {
      this.user = await ApiService.getUser();
      this.mainCardHolderController.text =
          this.user['mainCreditCard']['cardHolder'];
      this.mainCardNumberController.text =
          this.user['mainCreditCard']['cardNumber'];
      this.mainExpirationController.text =
          this.user['mainCreditCard']['expiration'];
      this.mainCVVController.text = this.user['mainCreditCard']['cvv'];
    } catch (e) {
      ToasterService.showToast(
          'error', 'An error occurred while getting the user!');
    }
  }

  void getCreditCards() async {
    try {
      var creditCards = await ApiService.getCreditCards();

      for (int i = 0; i < creditCards.length; i++) {
          CardItem newItem = new CardItem(
              cardId: creditCards[i]['cardId'],
              cardHolder: creditCards[i]['cardHolder'],
              cardNumber: creditCards[i]['cardNumber'],
              expiration: creditCards[i]['expiration'],
              cvv: creditCards[i]['cvv']);

        if (creditCards[i]['main']!=true) {
          this.cardsDropdownItems.add(
                DropdownMenuItem<String>(
                  value: i.toString(),
                  child: Text(creditCards[i]['cardNumber']),
                ),
              );
        }

        cardsData.add(newItem);
      }
    } catch (e) {
      ToasterService.showToast(
          'error', 'An error occurred while getting the cards!');
    }
  }

  Future<void> updateMainCreditCard(int cardId) async {
    try {
      await ApiService.updateCreditCard(
        cardId,
        this.mainCardHolderController.text,
        this.mainCardNumberController.text,
        this.mainExpirationController.text,
        this.mainCVVController.text,
      );

      ToasterService.showToast(
          'success', 'Main credit card updated successfully!');
    } catch (e) {
      print(e);
      ToasterService.showToast(
          'error', 'An error occurred while updating main credit card!');
    }
  }

  Future<void> updateCreditCard(int? cardId) async {
    try {
      if (cardId != null) {
        await ApiService.updateCreditCard(
          cardId,
          this.updateCardHolderController.text,
          this.updateCardNumberController.text,
          this.updateExpirationController.text,
          this.updateCVVController.text,
        );

        ToasterService.showToast(
            'success', 'Credit card updated successfully!');
      }
    } catch (e) {
      print(e);
      ToasterService.showToast(
          'error', 'An error occurred while updating credit card!');
    }
  }

  Future<void> createCreditCard() async {
    try {
      await ApiService.createNewCreditCard(
        this.createCardHolderController.text,
        this.createCardNumberController.text,
        this.createExpirationController.text,
        this.createCVVController.text,
      );

      ToasterService.showToast('success', 'New card created successfully!');

      setState(() {
        this.cardsDropdownItems = [];
      });

      this.getCreditCards();

    } catch (e) {
      print(e);
      ToasterService.showToast(
          'error', 'An error occurred while creating new card!');
    }
  }

  void getUpdateCardFormData(int index) {
    this.selectedCardId = this.cardsData[index].cardId;

    this.updateCardHolderController.text = this.cardsData[index].cardHolder;
    this.updateCardNumberController.text = this.cardsData[index].cardNumber;
    this.updateExpirationController.text = this.cardsData[index].expiration;
    this.updateCVVController.text = this.cardsData[index].cvv;
  }

  @override
  void initState() {
    super.initState();
    this.getUser();
    this.getCreditCards();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
          height: MediaQuery.of(context).size.height,
          decoration: BoxDecoration(
            color: Colors.white,
          ),
          child: DefaultTabController(
            length: 3,
            child: Scaffold(
              appBar: TabBar(
                labelColor: AppColors.MAIN_COLOR,
                labelPadding: EdgeInsets.only(top: 40.0, bottom: 10.0),
                tabs: [
                  Tab(icon: Icon(Icons.badge_rounded)),
                  Tab(icon: Icon(Icons.account_balance_wallet)),
                  Tab(icon: Icon(Icons.addchart_outlined)),
                ],
              ),
              body: TabBarView(
                children: [
                  SingleChildScrollView(
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
                                'MAIN CREDIT CARD',
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
                        Container(
                          margin: EdgeInsets.only(
                              top: 270, left: 10.0, right: 10.0),
                          child: Form(
                            key: _formKey,
                            child: Column(children: <Widget>[
                              TextFormField(
                                controller: this.mainCardHolderController,
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
                                controller: this.mainCardNumberController,
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
                                controller: this.mainExpirationController,
                                decoration: InputDecoration(
                                  hintText: 'Expiration',
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
                                controller: this.mainCVVController,
                                obscuringCharacter: '*',
                                decoration: InputDecoration(
                                  hintText: 'CVV',
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
                                        padding:
                                            const EdgeInsets.only(bottom: 20.0),
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
                                          onPressed: () => {
                                            updateMainCreditCard(
                                                user['mainCreditCard']
                                                    ['cardId'])
                                          },
                                          child: Padding(
                                            padding: const EdgeInsets.all(20.0),
                                            child: Text(
                                              'UPDATE',
                                              style: TextStyle(
                                                  color: Colors.white,
                                                  fontSize: 21),
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
                        ),
                      ],
                    ),
                  ),
                  SingleChildScrollView(
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
                                'OTHER CREDIT CARDS',
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
                                    key: _cardKey,
                                    hint: Text('Choose credit card'),
                                    items: cardsDropdownItems,
                                    onChanged: (dynamic newValue) async {
                                      getUpdateCardFormData(
                                          int.parse(newValue));
                                    },
                                    decoration: InputDecoration(
                                      border: OutlineInputBorder(
                                        borderSide:
                                            BorderSide(color: Colors.grey),
                                        borderRadius:
                                            BorderRadius.circular(4.0),
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
                        Container(
                          margin:
                              EdgeInsets.only(top: 270, left: 10, right: 10),
                          child: Form(
                            key: _updateKey,
                            child: Padding(
                              padding: EdgeInsets.all(10.0),
                              child: Column(children: <Widget>[
                                TextFormField(
                                  controller: this.updateCardHolderController,
                                  decoration: InputDecoration(
                                    hintText: 'Card holder',
                                    border: OutlineInputBorder(
                                      borderSide:
                                          BorderSide(color: Colors.grey),
                                      borderRadius: BorderRadius.circular(30.0),
                                    ),
                                  ),
                                ),
                                SizedBox(
                                  height: 10,
                                ),
                                TextFormField(
                                  controller: this.updateCardNumberController,
                                  decoration: InputDecoration(
                                    hintText: 'Card number',
                                    border: OutlineInputBorder(
                                      borderSide:
                                          BorderSide(color: Colors.grey),
                                      borderRadius: BorderRadius.circular(30.0),
                                    ),
                                  ),
                                ),
                                SizedBox(
                                  height: 10,
                                ),
                                TextFormField(
                                  controller: this.updateExpirationController,
                                  decoration: InputDecoration(
                                    hintText: 'Expiration',
                                    border: OutlineInputBorder(
                                      borderSide:
                                          BorderSide(color: Colors.grey),
                                      borderRadius: BorderRadius.circular(30.0),
                                    ),
                                  ),
                                ),
                                SizedBox(
                                  height: 10,
                                ),
                                TextFormField(
                                  controller: this.updateCVVController,
                                  obscuringCharacter: '*',
                                  decoration: InputDecoration(
                                    hintText: 'CVV',
                                    border: OutlineInputBorder(
                                      borderSide:
                                          BorderSide(color: Colors.grey),
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
                                          padding: const EdgeInsets.only(
                                              bottom: 20.0),
                                          child: ElevatedButton(
                                            style: ButtonStyle(
                                              backgroundColor:
                                                  MaterialStateProperty.all(
                                                      AppColors.MAIN_COLOR),
                                              shape: MaterialStateProperty.all<
                                                  RoundedRectangleBorder>(
                                                RoundedRectangleBorder(
                                                  borderRadius:
                                                      BorderRadius.circular(
                                                          40.0),
                                                ),
                                              ),
                                            ),
                                            onPressed: () => {
                                              if (selectedCardId != null)
                                                {
                                                  updateCreditCard(
                                                      selectedCardId)
                                                }
                                            },
                                            child: Padding(
                                              padding:
                                                  const EdgeInsets.all(20.0),
                                              child: Text(
                                                'UPDATE',
                                                style: TextStyle(
                                                    color: Colors.white,
                                                    fontSize: 21),
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
                          ),
                        ),
                      ],
                    ),
                  ),
                  SingleChildScrollView(
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
                                'CREATE NEW CARD',
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
                        Container(
                          margin: EdgeInsets.only(
                              top: 270, left: 10.0, right: 10.0),
                          child: Form(
                            key: _createKey,
                            child: Column(children: <Widget>[
                              TextFormField(
                                controller: this.createCardHolderController,
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
                                controller: this.createCardNumberController,
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
                                controller: this.createExpirationController,
                                decoration: InputDecoration(
                                  hintText: 'Expiration',
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
                                controller: this.createCVVController,
                                obscuringCharacter: '*',
                                decoration: InputDecoration(
                                  hintText: 'CVV',
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
                                        padding:
                                            const EdgeInsets.only(bottom: 20.0),
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
                                          onPressed: this.createCreditCard,
                                          child: Padding(
                                            padding: const EdgeInsets.all(20.0),
                                            child: Text(
                                              'CREATE',
                                              style: TextStyle(
                                                  color: Colors.white,
                                                  fontSize: 21),
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
                        ),
                      ],
                    ),
                  ),
                ],
              ),
            ),
          )),
    );
  }
}
