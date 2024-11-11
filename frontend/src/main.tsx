import { createBrowserRouter, RouterProvider } from "react-router-dom";
import React from "react";
import { Provider } from "react-redux";
import { store } from "./store";
import ReactDOM from "react-dom/client";
import "./index.css";
/* existing imports */
import Root from "./routes/root";
import ErrorPage from "./error-page";
import HomePage from "./Pages/HomePage/HomePage";
import LoginPage from "./Pages/Login/LoginPage";
import RegisterPage from "./Pages/Register/RegisterPage";
import LisPostPage from "./Pages/Post/ListPost";
import ProtectedRoute from "./routes/ProtectedRoute";
import { UserProvider } from "./Services/AuthApi/useAuth";
import { App } from "./App";
import CreatePostPage from "./Pages/Post/CreatePost";

const router = createBrowserRouter([
  {
    path: "/",
    element: <HomePage />,
    errorElement: <ErrorPage />,
  },
  {
    path: "Home",
    element: (
      <UserProvider>
        <ProtectedRoute>
          <App />
        </ProtectedRoute>
      </UserProvider>
    ),
  },
  {
    path: "Posts",
    element: (
      <UserProvider>
        <ProtectedRoute>
          <LisPostPage />
        </ProtectedRoute>
      </UserProvider>
    ),
  },
  {
    path: "Add/Post",
    element: (
      <UserProvider>
        <ProtectedRoute>
          <CreatePostPage />
        </ProtectedRoute>
      </UserProvider>
    ),
  },
  {
    path: "Login",
    element: <LoginPage />,
  },
  {
    path: "Register",
    element: <RegisterPage />,
  },
]);

ReactDOM.createRoot(document.getElementById("root")).render(
  <Provider store={store}>
    <React.StrictMode>
      <RouterProvider router={router} />
    </React.StrictMode>
  </Provider>
);
