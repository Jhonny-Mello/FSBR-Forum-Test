import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Form, Input, Button, Checkbox, notification, Spin } from "antd";
import { UserOutlined, LockOutlined } from "@ant-design/icons";
import { useLoginMutation } from "../../Services/AuthApi/authApi";
import { useAuth } from "../../Services/AuthApi/useAuth";
import { Navigate } from "react-router-dom";
import "./Login.css";
import { UserProfile } from "../../Models/User";

const Login: React.FC = () => {
  const [login] = useLoginMutation(); // Hook
  const [loading, setLoading] = useState(false); // Para controlar o estado de carregamento
  const [token, setToken] = useState<string | null>(null);
  const [user, setUser] = useState<UserProfile | null>(null);

  const navigate = useNavigate();

  // Função chamada quando o formulário é enviado
  const onFinish = async (values: any) => {
    setLoading(true); // Ativa o estado de loading

    try {
      const { username, password } = values;
      const response = await login({ username, password })
        .unwrap()
        .then((saida) => {
          console.log(saida)
            localStorage.setItem("token", saida?.token);
            const userObj = {
              userName: saida?.userName,
              email: saida?.email,
              id: saida?.id,
            };
            localStorage.setItem("user", JSON.stringify(userObj));
            setToken(saida?.token!);
            setUser(userObj!);
            // Sucesso
            notification.success({
              message: "Login bem-sucedido!",
              description: "Você foi autenticado com sucesso.",
            });
        })
        .catch((error) => {
          console.log(error)
          notification.error({
            message: "Erro de autenticação",
            description: "Usuário ou senha inválidos!",
          });
        });


      console.log("Login response:", response);

      navigate("/home");
    } catch (error) {
      // Erro
      notification.error({
        message: "Erro de autenticação",
        description: "Usuário ou senha inválidos!",
      });
    } finally {
      setLoading(false); // Desativa o estado de loading
    }
  };

  // Função chamada quando a validação falha
  const onFinishFailed = (errorInfo: any) => {
    console.log("Failed:", errorInfo);
  };

  return (
    <div className="login-container">
      <h2>Login</h2>
      <Form
        name="login"
        className="login-form"
        initialValues={{ remember: true }}
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
      >
        {/* Campo de Email */}
        <Form.Item
          name="username"
          rules={[
            {
              required: true,
              message: "Por favor, insira seu email ou nome de usuário!",
            },
          ]}
        >
          <Input
            prefix={<UserOutlined className="site-form-item-icon" />}
            placeholder="Email ou nome de usuário"
          />
        </Form.Item>

        {/* Campo de Senha */}
        <Form.Item
          name="password"
          rules={[
            { required: true, message: "Por favor, insira sua senha!" },
            { min: 6, message: "A senha deve ter no mínimo 6 caracteres." },
          ]}
        >
          <Input
            prefix={<LockOutlined className="site-form-item-icon" />}
            type="password"
            placeholder="Senha"
          />
        </Form.Item>

        {/* Checkbox de lembrar senha */}
        <Form.Item name="remember" valuePropName="checked">
          <Checkbox>Lembrar de mim</Checkbox>
        </Form.Item>

        {/* Botão de Login */}
        <Form.Item>
          <Button
            type="primary"
            htmlType="submit"
            block
            className="login-form-button"
            loading={loading}
          >
            {loading ? "Carregando..." : "Entrar"}
          </Button>
        </Form.Item>

        {/* Link para "Esqueceu a senha?" */}
        {/* <Form.Item>
          <a className="login-form-forgot" href="/">
            Esqueceu a senha?
          </a>
        </Form.Item> */}

        {/* Link para cadastro */}
        <Form.Item>
          Não tem uma conta? <a href="/register">Cadastre-se!</a>
        </Form.Item>
      </Form>
    </div>
  );
};

export default Login;
