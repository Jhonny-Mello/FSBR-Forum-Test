import React from "react";
import { Navigate, useLocation } from "react-router-dom";
import { useAuth } from "../Services/AuthApi/useAuth";
import NavMenu from "../Components/NavMenu";

type Props = { children: React.ReactNode };

const ProtectedRoute = ({ children }: Props) => {
  const location = useLocation();
  const { isLoggedIn } = useAuth();

  return isLoggedIn() ? (
    <>
    {<NavMenu />}
    <div id="detail" style={{overflow:'auto'}}>
      {children}
    </div>
    </>
  ) : (
    <Navigate to="/login" state={{ from: location }} replace />
  );
};

export default ProtectedRoute;
