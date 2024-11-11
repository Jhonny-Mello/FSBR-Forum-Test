import React, { useState } from "react";
import {
  useGetAllPostsQuery,
  useUpdatePostMutation,
  useCreateCommentMutation,
  useUpdateCommentMutation,
  useCreateAvaliacaoMutation,
  useDeletePostMutation,
  useDeleteCommentMutation,
} from "../../Services/AuthApi/authApi";
import { GenericPaginationModel, Post, PainelForum } from "../../Models/Post";
import {
  Button,
  Card,
  Rate,
  Avatar,
  List,
  Row,
  Col,
  Space,
  Input,
  Form,
  Flex,
} from "antd";
import {
  LeftOutlined,
  RightOutlined,
  PlusOutlined,
  MinusOutlined,
  EditOutlined,
  SaveOutlined,
  DeleteOutlined,
} from "@ant-design/icons";
import { Comentario } from "../../Models/Comment";
import hero from "../../Components/Hero/Hero.png";
import { useAuth } from "../../Services/AuthApi/useAuth";

const PostsList: React.FC = () => {
  const [pagination, setPagination] = useState<
    GenericPaginationModel<PainelForum>
  >({
    pageNumber: 1,
    pageSize: 5,
    Value: { IsDescending: true },
  });
  
  const [updatePost] = useUpdatePostMutation();
  const [createAvaliacao] = useCreateAvaliacaoMutation();
  const [createComment] = useCreateCommentMutation();
  const [UpdateComment] = useUpdateCommentMutation();
  const [DeleteComment] = useDeleteCommentMutation();
  const [DeletePost] = useDeletePostMutation();

  const [rating, setRating] = useState<number>(0);

  const handleAddRating = async (postId: string, value: number) => {
    console.log(value);
    if (value > 0) {
      await createAvaliacao({ postId, value });
      refetch();
      setPagination({ ...pagination, pageNumber: pagination.pageNumber });
    }
  };

  const [isEditing, setIsEditing] = useState<{ [postId: string]: boolean }>({});
  const [editedPost, setEditedPost] = useState<{
    [postId: string]: { title: string; content: string };
  }>({});

  const [isEditingComment, setIsCommentEditing] = useState<{
    [commentId: string]: boolean;
  }>({});
  const [editedComment, setEditedComment] = useState<{
    [commentId: string]: { content: string };
  }>({});

  const { data, error, isLoading, refetch } = useGetAllPostsQuery(pagination);

  const calculateAverageRating = (ratings: number[]) => {
    if (!ratings || ratings.length === 0) return 0;
    const total = ratings.reduce((acc, rating) => acc + rating, 0);
    return total / ratings.length;
  };

  const [visibleComments, setVisibleComments] = useState<{
    [postId: string]: boolean;
  }>({});
  const [visibleCommentarea, setVisibleCommentArea] = useState<{
    [postId: string]: boolean;
  }>({});
  const [newCommentContent, setNewCommentContent] = useState<{
    [postId: string]: string;
  }>({});

  const toggleCommentsAreaVisibility = (postId: string) => {
    setVisibleCommentArea((prev) => ({
      ...prev,
      [postId]: !prev[postId],
    }));
  };

  const toggleCommentsVisibility = (postId: string) => {
    setVisibleComments((prev) => ({
      ...prev,
      [postId]: !prev[postId],
    }));
  };

  const handleDeletePost = async (postId: string) => {
    try {
      await DeletePost(postId);
      refetch();
      setIsEditing((prev) => ({ ...prev, [postId]: false }));
    } catch (error) {
      console.error("Erro ao salvar a postagem:", error);
    }
  };

  const handleDeleteComment = async (postId: string) => {
    try {
      await DeleteComment(postId);
      refetch();
      setIsEditing((prev) => ({ ...prev, [postId]: false }));
    } catch (error) {
      console.error("Erro ao salvar a postagem:", error);
    }
  };

  const handleSavePost = async (postId: string) => {
    const { title, content } = editedPost[postId];
    try {
      await updatePost({ id: postId, postDto: { title, content } });
      refetch();
      setIsEditing((prev) => ({ ...prev, [postId]: false }));
    } catch (error) {
      console.error("Erro ao salvar a postagem:", error);
    }
  };

  const handleEditPost = (postId: string, title: string, content: string) => {
    setIsEditing((prev) => ({ ...prev, [postId]: true }));
    setEditedPost((prev) => ({
      ...prev,
      [postId]: { title, content },
    }));
  };

  const handleEditComment = (commentId: string, content: string) => {
    setIsCommentEditing((prev) => ({ ...prev, [commentId]: true }));
    setEditedComment((prev) => ({
      ...prev,
      [commentId]: { content },
    }));
  };

  const handleSaveComment = async (commentId: string) => {
    const { content } = editedComment[commentId];
    try {
      await UpdateComment({ id: commentId, content });
      refetch();
      setIsCommentEditing((prev) => ({ ...prev, [commentId]: false }));
    } catch (error) {
      console.error("Erro ao salvar o comentário:", error);
    }
  };

  const handleAddComment = async (postId: string) => {
    if (newCommentContent[postId].trim() === "") return; // Não permite comentário vazio
    console.log(newCommentContent[postId]);
    try {
      await createComment({ postId, content: newCommentContent[postId] })
        .then((response) => {
          console.log(response);
        })
        .catch((response) => {
          console.log(response);
        });
      newCommentContent[postId] = "";
      visibleCommentarea[postId] = false;
      refetch(); // Recarrega os dados dos comentários
      setPagination({ ...pagination, pageNumber: pagination.pageNumber });
    } catch (error) {
      console.error("Erro ao adicionar comentário:", error);
    }
  };

  if (isLoading) return <div>Carregando...</div>;
  if (error) return <div>Erro ao carregar postagens</div>;
  if (!data?.data?.length) {
    return <p>No posts found.</p>;
  }

  const { user, token, logout, isLoggedIn } = useAuth();

  return (
    <div>
      <h3>Fórum FSBR test</h3>
      <Row gutter={[16, 16]} style={{ width: "100%" }}>
        {data?.data.map((post: Post) => {
          const averagePostRating = calculateAverageRating(
            post.avaliacoes.map((x) => x.value)
          );

          const isEditingPost = isEditing[post.id];
          const editedTitle = editedPost[post.id]?.title || post.tema;
          const editedContent =
            editedPost[post.id]?.content || post.postContent;

          return (
            <Col key={post.id} style={{ maxWidth: "690px", width: "100%" }}>
              <Card
                style={{ maxWidth: "none", flex: "auto", width: "100%" }}
                actions={[
                  <Flex justify="space-between">
                    {isEditingPost ? (
                      <Button
                        icon={<SaveOutlined />}
                        onClick={() => handleSavePost(post.id)}
                      >
                        Salvar
                      </Button>
                    ) : (
                      <div></div>
                    )}
                    <Button
                      icon={
                        visibleCommentarea[post.id] ? (
                          <MinusOutlined />
                        ) : (
                          <PlusOutlined />
                        )
                      }
                      onClick={() => toggleCommentsAreaVisibility(post.id)}
                    >
                      {"Novo Comentário"}
                    </Button>
                    {post.appUserId == user?.id ? (
                      <>
                        <Button
                          icon={<EditOutlined />}
                          onClick={() =>
                            handleEditPost(post.id, post.tema, post.postContent)
                          }
                        >
                          Editar
                        </Button>
                        <Button
                          icon={<DeleteOutlined />}
                          onClick={() => handleDeletePost(post.id)}
                        >
                          Excluir
                        </Button>
                      </>
                    ) : (
                      <div></div>
                    )}
                  </Flex>,
                ]}
              >
                <Flex justify="space-between">
                  <Space align="start">
                    <Avatar src={hero} />
                    <span>{post.appUser.normalizedUserName}</span>
                  </Space>
                  <Row>
                    <Col span={24}>
                      <span
                        style={{
                          fontSize: "12px",
                          color: "#c3c3c3",
                          textAlign: "center",
                          alignSelf: "center",
                          marginRight: "10px",
                        }}
                      >
                        ({post.avaliacoes.length})
                      </span>
                      <Rate
                        onChange={(value) => {
                          setRating(value);
                          handleAddRating(post.id, value);
                        }}
                        value={averagePostRating}
                      />
                    </Col>
                  </Row>
                </Flex>

                {isEditingPost ? (
                  <div>
                    <Form>
                      <Form.Item label="Título">
                        <Input
                          value={editedTitle}
                          onChange={(e) =>
                            setEditedPost((prev) => ({
                              ...prev,
                              [post.id]: {
                                ...prev[post.id],
                                title: e.target.value,
                              },
                            }))
                          }
                        />
                      </Form.Item>
                      <Form.Item label="Conteúdo">
                        <Input.TextArea
                          value={editedContent}
                          onChange={(e) =>
                            setEditedPost((prev) => ({
                              ...prev,
                              [post.id]: {
                                ...prev[post.id],
                                content: e.target.value,
                              },
                            }))
                          }
                        />
                      </Form.Item>
                    </Form>
                  </div>
                ) : (
                  <>
                    <h4>{post.tema || "Sem título disponível"}</h4>
                    <p style={{ maxWidth: "100%", wordWrap: "break-word" }}>
                      {post.postContent || "Sem conteúdo disponível"}
                    </p>
                  </>
                )}
                {/* Comentários */}
                {post.comentarios?.length > 0 && (
                  <div style={{ marginTop: "10px" }}>
                    <Button
                      type="link"
                      icon={
                        visibleComments[post.id] ? (
                          <MinusOutlined />
                        ) : (
                          <PlusOutlined />
                        )
                      }
                      onClick={() => toggleCommentsVisibility(post.id)}
                    >
                      {visibleComments[post.id]
                        ? "Ocultar Comentários"
                        : "Ver Comentários"}
                    </Button>

                    {visibleComments[post.id] && (
                      <List
                        style={{ overflow: "auto", maxHeight: "400px" }}
                        itemLayout="horizontal"
                        dataSource={post.comentarios}
                        renderItem={(comment: Comentario) => {
                          const averageCommentRating = calculateAverageRating(
                            comment.avaliacoes.map((x) => x.value)
                          );
                          const isEditing = isEditingComment[comment.id];
                          const editedContent =
                            editedComment[comment.id]?.content ||
                            comment.content;

                          return (
                            <List.Item>
                              <List.Item.Meta
                                avatar={<Avatar src={hero} />}
                                title={
                                  <Flex justify="space-between">
                                    <b>{comment.appUser.normalizedUserName}</b>
                                    <Col span={12}>
                                      <span
                                        style={{
                                          fontSize: "12px",
                                          color: "#c3c3c3",
                                          textAlign: "center",
                                          alignSelf: "center",
                                          marginRight: "10px",
                                        }}
                                      >
                                        ({comment.avaliacoes.length})
                                      </span>
                                      <Rate
                                        onChange={(value) => {
                                          setRating(value);
                                          handleAddRating(comment.id, value);
                                        }}
                                        value={averageCommentRating}
                                      />
                                      <Flex justify="space-between">
                                        {isEditing ? (
                                          <Button
                                            icon={<SaveOutlined />}
                                            onClick={() =>
                                              handleSaveComment(comment.id)
                                            }
                                          >
                                            Salvar
                                          </Button>
                                        ) : null}
                                        {comment.appUser.id === user?.id && (
                                          <>
                                            <Button
                                              icon={<EditOutlined />}
                                              onClick={() =>
                                                handleEditComment(
                                                  comment.id,
                                                  comment.content
                                                )
                                              }
                                            >
                                              Editar
                                            </Button>
                                            <Button
                                              icon={<DeleteOutlined />}
                                              onClick={() =>
                                                handleDeleteComment(comment.id)
                                              }
                                            >
                                              Excluir
                                            </Button>
                                          </>
                                        )}
                                      </Flex>
                                    </Col>
                                  </Flex>
                                }
                                description={
                                  <>
                                    {isEditing ? (
                                      <Form>
                                        <Form.Item label="Conteúdo">
                                          <Input.TextArea
                                            value={editedContent}
                                            onChange={(e) =>
                                              setEditedComment((prev) => ({
                                                ...prev,
                                                [comment.id]: {
                                                  content: e.target.value,
                                                },
                                              }))
                                            }
                                          />
                                        </Form.Item>
                                      </Form>
                                    ) : (
                                      <p
                                        style={{
                                          maxWidth: "100%",
                                          wordWrap: "break-word",
                                        }}
                                      >
                                        {comment.content ||
                                          "Sem conteúdo disponível"}
                                      </p>
                                    )}
                                  </>
                                }
                              />
                            </List.Item>
                          );
                        }}
                      />
                    )}
                  </div>
                )}
                {visibleCommentarea[post.id] && (
                  <div style={{ marginTop: "15px" }}>
                    <Input.TextArea
                      rows={3}
                      value={newCommentContent[post.id]}
                      onChange={(e) =>
                        setNewCommentContent((prev) => ({
                          ...prev,
                          [post.id]: e.target.value,
                        }))
                      }
                      placeholder="Adicionar um novo comentário"
                    />
                    <Button
                      style={{ marginTop: "10px" }}
                      type="primary"
                      icon={<SaveOutlined />}
                      onClick={() => handleAddComment(post.id)}
                    >
                      Adicionar Comentário
                    </Button>
                  </div>
                )}
              </Card>
            </Col>
          );
        })}
      </Row>
      <div style={{ textAlign: "center", marginTop: "20px" }}>
        <Button
          onClick={() =>
            setPagination({
              ...pagination,
              pageNumber: pagination.pageNumber - 1,
            })
          }
          disabled={data.isFirstpage}
          icon={<LeftOutlined />}
        >
          Anterior
        </Button>
        <Button
          onClick={() =>
            setPagination({
              ...pagination,
              pageNumber: pagination.pageNumber + 1,
            })
          }
          disabled={data.isLastpage}
          icon={<RightOutlined />}
        >
          Próximo
        </Button>
      </div>
    </div>
  );
};

export default PostsList;
