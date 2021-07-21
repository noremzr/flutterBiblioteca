class UsuarioFilter {
  String usuario = "";

  Map toMap() {
    var map = Map();
    map["usuario"] = usuario;
    return map;
  }
}
