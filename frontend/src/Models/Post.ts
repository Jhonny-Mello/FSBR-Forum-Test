import { avaliacao } from "./Avaliacao";
import { Comentario } from "./Comment";
import { User } from "./User";

export interface Post {
  id: string;
  tema: string;
  postContent: string;
  createdOn: string;
  avaliacoes: avaliacao[];
  comentarios: Comentario[];
  appUserId: string;
  appUser: User;
}

export interface CreatePostDto {
  title: string;
  content: string;
}

export interface UpdatePostRequestDto {
  title: string;
  content: string;
}

export interface PagedResponse<T> {
  data: T;
  PageNumber: number;
  PageSize: number;
  TotalPages: number;
  TotalRecords: number;
  isFirstpage: boolean;
  isLastpage: boolean;
  
}

export interface GenericPaginationModel<T> {
  pageNumber: number;
  pageSize: number;
  totalRecords: number;
  totalPages: number;
  Value: T;
}

export interface PainelForum {
  search: string;
  avaliacao: number;
  IsDescending: boolean;
}
