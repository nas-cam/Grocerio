class LoggedUser {
  String username;
  int role;
  String roleName;
  int id;
  int accountId;

  LoggedUser(
      {this.username = '',
      this.role = 0,
      this.roleName = '',
      this.id = 0,
      this.accountId = 0});

  factory LoggedUser.fromJson(Map<String, dynamic> json) {
    return LoggedUser(
      username: json['username'],
      role: json['role'],
      roleName: json['roleName'],
      id: json['id'],
      accountId: json['accountId'],
    );
  }
}
