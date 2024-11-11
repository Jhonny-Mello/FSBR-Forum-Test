import { configureStore } from '@reduxjs/toolkit';
import { authApi } from './services/AuthApi/authApi';

export const store = configureStore({
  reducer: {
    [authApi.reducerPath]: authApi.reducer, // Adiciona o authApi no store
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(authApi.middleware),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
