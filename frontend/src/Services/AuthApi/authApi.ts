import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import {
  Post,
  CreatePostDto,
  UpdatePostRequestDto,
  PagedResponse,
  GenericPaginationModel,
  PainelForum,
} from "../../Models/Post";
import { RootState } from "../store";
import { Comentario } from "../../Models/Comment";
import { Avaliacao } from "../../Models/Avaliacao";

// Definindo a URL base da API
const BASE_URL = "https://localhost:7281/api/";

const token = localStorage.getItem("token");

// Serviço RTK Query para Posts
export const authApi = createApi({
  reducerPath: "postApi",
  baseQuery: fetchBaseQuery({
    baseUrl: BASE_URL,
    prepareHeaders: (headers, { getState }) => {
      
      if (token) {
        headers.set("Authorization", `Bearer ${token}`);
      }
      return headers;
    },
  }),
  endpoints: (builder) => ({
    login: builder.mutation<any, { username: string; password: string }>({
      query: (loginData) => ({
        url: "account/login",
        method: "POST",
        body: loginData,
      }),
    }),
    register: builder.mutation<
      any,
      { username: string; email: string; password: string }
    >({
      query: (registerData) => ({
        url: "account/register",
        method: "POST",
        body: registerData,
      }),
    }),
    getAllPosts: builder.query<
      PagedResponse<Post[]>,
      GenericPaginationModel<PainelForum>
    >({
      query: (pagination) => {
        const { pageNumber, pageSize, Value } = pagination;
        const queryParams: any = {
          PageNumber: pageNumber,
          PageSize: pageSize,
          "Value.IsDescending": Value.IsDescending,
          "Value.search": Value.search,
          "Value.avaliacao": Value.avaliacao,
        };
        return {
          url: "Post",
          params: queryParams,
          method: "GET",
        };
      },
    }),
    getPostById: builder.query<Post, string>({
      query: (id) => ({
        url: `Post/${id}`,
        method: "GET",
      }),
    }),
    createPost: builder.mutation<Post, { title: string; Content: string }>({
      query: ({ title, Content }) => {
        // const postDto = ;
        console.log({ title, Content })
        return {
          url: "Post",
          method: "POST",
          params: { title, Content },
        };
      },
    }),
    updatePost: builder.mutation<
      Post,
      { id: string; postDto: UpdatePostRequestDto }
    >({
      query: ({ id, postDto }) => ({
        url: `Post/${id}`,
        method: "PUT",
        body: postDto,
      }),
    }),
    deletePost: builder.mutation<{ id: string }, string>({
      query: (id) => ({
        url: `Post/${id}`,
        method: "DELETE",
      }),
    }),
    createComment: builder.mutation<
      Comentario,
      { postId: string; content: string }
    >({
      query: ({ postId, content }) => ({
        url: "Comment",
        method: "POST",
        body: { postId, content, UserId: "" }, 
      }),
    }),
    updateComment: builder.mutation<
      Comentario,
      { id: string; content: string }
    >({
      query: ({ id, content }) => ({
        url: `Comment/${id}`,
        method: "PUT",
        body: { content },
      }),
    }),
    deleteComment: builder.mutation<{ id: string }, string>({
      query: (id) => ({
        url: `Comment/${id}`,
        method: "DELETE",
      }),
    }),
    createAvaliacao: builder.mutation<
      Avaliacao,
      { postId: string; value: number }
    >({
      query: ({ postId, value }) => ({
        url: "Avaliacao",
        method: "POST",
        body: { PostId: postId, value, UserId: "" }, 
      }),
    }),
    deleteAvaliacao: builder.mutation<Avaliacao, { id: string }>({
      query: (id) => ({
        url: `Avaliacao/${id}`,
        method: "DELETE",
      }),
    }),
  }),
});

export const {
  useGetAllPostsQuery,
  useGetPostByIdQuery,
  useCreatePostMutation,
  useUpdatePostMutation,
  useDeletePostMutation,
  useLoginMutation,
  useRegisterMutation,
  useCreateCommentMutation,
  useUpdateCommentMutation,
  useDeleteCommentMutation,
  useCreateAvaliacaoMutation,
  useDeleteAvaliacaoMutation,
} = authApi;
