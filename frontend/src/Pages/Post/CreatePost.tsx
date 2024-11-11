import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useCreatePostMutation } from "../../Services/AuthApi/authApi";
import { Button, Form, Input, message, Spin, Typography } from "antd";
import { SaveOutlined } from "@ant-design/icons";

const { Title } = Typography;

const CreatePostPage: React.FC = () => {
  const [createPost, { isLoading, isSuccess, error }] = useCreatePostMutation();
  const [form] = Form.useForm();
  const navigate = useNavigate();

  const [postDetails, setPostDetails] = useState({
    tema: "",
    postContent: "",
  });

  const handleSubmit = async (values: any) => {
    try {
      const { tema, postContent } = values;

      console.log({ tema, postContent })
      await createPost({title: tema, Content: postContent}).unwrap();
      message.success("Post criado com sucesso!");
      navigate("/Posts"); 
    } catch (err) {
      message.error("Erro ao criar o post, tente novamente!");
      console.log(err);
    }
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setPostDetails((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleChangetxta = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
    const { name, value } = e.target;
    setPostDetails((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  return (
    <div style={{ maxWidth: "600px", margin: "0 auto" }}>
      <Title level={2}>Nova Publicação</Title>

      {isLoading && <Spin />}

      <Form
        form={form}
        name="create-post-form"
        onFinish={handleSubmit}
        initialValues={postDetails}
        layout="vertical"
      >
        <Form.Item
          name="tema"
          label="Título"
          rules={[{ required: true, message: "Por favor, insira o título!" }]}
        >
          <Input
            value={postDetails.tema}
            onChange={handleChange}
            name="tema"
            placeholder="Digite o título do post"
          />
        </Form.Item>

        <Form.Item
          name="postContent"
          label="Conteúdo"
          rules={[{ required: true, message: "Por favor, insira o conteúdo!" }]}
        >
          <Input.TextArea
            value={postDetails.postContent}
            onChange={handleChangetxta}
            name="postContent"
            rows={6}
            placeholder="Digite o conteúdo do post"
          />
        </Form.Item>

        <Form.Item>
          <Button
            type="primary"
            htmlType="submit"
            icon={<SaveOutlined />}
            loading={isLoading}
          >
            Criar Post
          </Button>
        </Form.Item>
      </Form>

      {isSuccess && (
        <div style={{ color: "green", marginTop: "20px" }}>
          Post criado com sucesso!
        </div>
      )}
      {error && (
        <div style={{ color: "red", marginTop: "20px" }}>
          Algo deu errado. Por favor, tente novamente.
        </div>
      )}
    </div>
  );
};

export default CreatePostPage;
