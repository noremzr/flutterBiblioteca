import 'package:biblioteca/Menu/menu.dart';
import 'package:biblioteca/models/usuario/usuario_model.dart';
import 'package:flutter/material.dart';
import 'package:biblioteca/services/usuarios_service.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({Key? key, required this.title}) : super(key: key);
  final String title;

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  UsuarioService userService = UsuarioService();
  String usuario = "";
  String senha = "";
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: Center(
        child: SizedBox(
          width: 300,
          height: 400,
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: <Widget>[
              TextField(
                onChanged: (text) {
                  setState(() {
                    usuario = text;
                  });
                },
                decoration: const InputDecoration(
                  hintText: 'Usuário',
                ),
              ),
              TextField(
                onChanged: (text) {
                  setState(() {
                    senha = text;
                  });
                },
                decoration: const InputDecoration(
                  hintText: 'Senha',
                ),
              ),
              Padding(
                padding: const EdgeInsets.fromLTRB(0.0, 12.0, 0.0, 0.0),
                child: Row(
                  children: [
                    Column(
                      mainAxisAlignment: MainAxisAlignment.start,
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Container(
                          child: ElevatedButton(
                            onPressed: () {},
                            child: const Text('Cadastre-se'),
                          ),
                          alignment: Alignment.centerRight,
                        ),
                      ],
                    ),
                    Column(
                      mainAxisAlignment: MainAxisAlignment.end,
                      crossAxisAlignment: CrossAxisAlignment.end,
                      children: [
                        Container(
                          child: ElevatedButton(
                            onPressed: () {
                              validaUsuario();
                            },
                            child: const Text('Entrar'),
                          ),
                          alignment: Alignment.centerRight,
                        ),
                      ],
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  void validaUsuario() async {
    Usuario usuarioModel = Usuario(usuario: usuario, senha: senha);
    if (await userService.authenticateUsuario(usuarioModel)) {
      Navigator.push(
        context,
        MaterialPageRoute(builder: (context) => const MenuPage()),
      );
    }
  }
}
