class Store {
  int id;
  String name;
  String description;

  Store({
    this.id = 0,
    this.name = '',
    this.description = '',
  });

  factory Store.fromJson(Map<String, dynamic> json) {
    return Store(
      id: json['id'],
      name: json['name'],
      description: json['description'],
    );
  }
}
