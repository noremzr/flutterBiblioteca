import 'dart:convert';

import 'package:biblioteca/models/usuario/usuario_filter.dart';
import 'package:biblioteca/models/usuario/usuario_model.dart';
import 'package:http/http.dart' as http;
import 'package:biblioteca/services/shared/api.dart' as api;

class UsuarioService {
  Future<List<Usuario>> getUsuarios(UsuarioFilter usuario) async {
    String url = api.Api.getApi();
    final response = await http.post(
      Uri.parse('${url}api/usuarios/GetUsuarios'),
      body: usuario.toMap(),
    );

    final parsed = jsonDecode(response.body).cast<Map<String, dynamic>>();
    return parsed.map<Usuario>((json) => Usuario.fromJson(json)).toList();
  }

  Future<bool> authenticateUsuario(Usuario usuario) async {
    UsuarioFilter userFilter = UsuarioFilter();
    userFilter.usuario = usuario.usuario;

    List<Usuario> listaUsuarios = await getUsuarios(userFilter);
    if (listaUsuarios.length > 1) {
      throw Exception(
          'Há dois usuarios cadastrados com o usuário ${usuario.usuario} resolva antes de continuar');
    }
    if (listaUsuarios.isEmpty) {
      throw Exception('Não há usuarios cadastrados com esse identificador!');
    }
    Usuario user = listaUsuarios.first;
    if (usuario.senha != user.usuario) {
      return false;
    }
    return true;
  }
}
