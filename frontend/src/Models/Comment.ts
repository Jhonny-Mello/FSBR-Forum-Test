import { avaliacao } from "./Avaliacao";
import { User } from "./User";

export type CommentPost = {
  title: string;
  content: string;
};

export type CommentGet = {
  title: string;
  content: string;
  createdBy: string;
};

export type Comentario = {
  appUser: User;
  avaliacoes: avaliacao[];
  content: string;
  createdOn: string;
  id: string;
};
