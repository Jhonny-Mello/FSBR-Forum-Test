import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Form, Input, Button, notification } from "antd";
import { UserOutlined, LockOutlined, MailOutlined } from "@ant-design/icons";
import { useRegisterMutation } from "../../Services/AuthApi/authApi"; // Importando o hook
import "./Register.css";

const Register: React.FC = () => {
  const [register] = useRegisterMutation(); // Hook para a mutação de registro
  const [loading, setLoading] = useState(false); // Para controlar o estado de carregamento
  const navigate = useNavigate();

  // Função chamada quando o formulário é enviado
  const onFinish = async (values: any) => {
    setLoading(true); // Ativa o estado de loading

    try {
      const { username, email, password } = values;
      const response = await register({ username, email, password })
        .unwrap()
        .then(() => {
          // Sucesso
          notification.success({
            message: "Registro bem-sucedido!",
            description: "Você foi registrado com sucesso.",
          });
          // console.log("success response:", response);
          navigate("/login");
        })
        .catch((args) => {
          console.log("catch error response:", args);

          notification.error({
            message: "Desculpe o seguinte erro ocorreu :(",
            description: args.data,
          });
          
        });
    } catch (error) {
      // Erro
      console.log("any response:", error);
      notification.error({
        message: "Erro ao registrar",
        description: "Ocorreu um erro durante o registro. Tente novamente.",
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
    <div className="register-container">
      <h2>Cadastrar</h2>
      <Form
        name="register"
        className="register-form"
        initialValues={{ remember: true }}
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
      >
        {/* Campo de Nome de Usuário */}
        <Form.Item
          name="username"
          rules={[
            {
              required: true,
              message: "Por favor, insira seu nome de usuário!",
            },
            {
              min: 3,
              message: "O nome de usuário deve ter pelo menos 3 caracteres!",
            },
          ]}
        >
          <Input
            prefix={<UserOutlined className="site-form-item-icon" />}
            placeholder="Nome de usuário"
          />
        </Form.Item>

        {/* Campo de Email */}
        <Form.Item
          name="email"
          rules={[
            { required: true, message: "Por favor, insira seu email!" },
            { type: "email", message: "O formato do email é inválido!" },
          ]}
        >
          <Input
            prefix={<MailOutlined className="site-form-item-icon" />}
            placeholder="Email"
          />
        </Form.Item>

        {/* Campo de Senha */}
        <Form.Item
          name="password"
          rules={[
            { required: true, message: "Por favor, insira sua senha!" },
            { min: 6, message: "A senha deve ter no mínimo 6 caracteres!" },
          ]}
        >
          <Input
            prefix={<LockOutlined className="site-form-item-icon" />}
            type="password"
            placeholder="Senha"
          />
        </Form.Item>

        {/* Campo de Confirmação de Senha */}
        <Form.Item
          name="confirmPassword"
          dependencies={["password"]}
          rules={[
            { required: true, message: "Por favor, confirme sua senha!" },
            ({ getFieldValue }) => ({
              validator(_, value) {
                if (!value || getFieldValue("password") === value) {
                  return Promise.resolve();
                }
                return Promise.reject(new Error("As senhas não coincidem!"));
              },
            }),
          ]}
        >
          <Input
            prefix={<LockOutlined className="site-form-item-icon" />}
            type="password"
            placeholder="Confirmar senha"
          />
        </Form.Item>

        {/* Botão de Registro */}
        <Form.Item>
          <Button
            type="primary"
            htmlType="submit"
            block
            className="register-form-button"
            loading={loading} // Exibe o ícone de loading enquanto a requisição está sendo processada
          >
            {loading ? "Carregando..." : "Cadastrar"}
          </Button>
        </Form.Item>

        {/* Link para Login */}
        <Form.Item>
          Já tem uma conta? <a href="/login">Faça login aqui!</a>
        </Form.Item>
      </Form>
    </div>
  );
};

export default Register;
