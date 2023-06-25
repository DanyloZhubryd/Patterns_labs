import http from "../http-common";
import { PayloadAction, createAsyncThunk, createSlice } from "@reduxjs/toolkit";

export interface TUser {
  id: number;
  username: string;
}

interface TUserState {
  users: TUser[];
}

const initialState: TUserState = {
  users: [],
};

export const fetchUsers = createAsyncThunk("users/fetch", async () => {
  const response = await http.get<Array<TUser>>("/User");
  const data = response.data;
  return data;
});

export const UserSlice = createSlice({
  name: "users",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(fetchUsers.fulfilled, (state, action) => {
      state.users = action.payload;
    });
  },
});
