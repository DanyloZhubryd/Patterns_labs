import http from "../http-common";
import { PayloadAction, createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { TStory } from "./storySlice";

export interface TComment {
  id: number;
  text: string;
  userId: number;
  storyId: number;
}

interface TCommentState {
  comments: TComment[];
}

const initialState: TCommentState = {
  comments: [],
};

export const fetchComments = createAsyncThunk(
  "comments/fetch",
  async (storyId: number) => {
    const response = await http.get<Array<TComment>>(
      `story/${storyId}/Comment`
    );
    const data = response.data;
    return data;
  }
);

export const editComment = createAsyncThunk(
  "comments/edit",
  async (comment: TComment) => {
    const preparedComment: Omit<TComment, "id"> = { ...comment };
    await http.put(
      `/story/${comment.storyId}/Comment/${comment.id}`,
      preparedComment
    );
  }
);

export const CommentSlice = createSlice({
  name: "comment",
  initialState,
  reducers: {
    editCommentLocal: (state, action: PayloadAction<TComment>) => {
      state.comments.splice(
        state.comments.findIndex((val) => val.id === action.payload.id),
        1,
        { ...action.payload }
      );
    },
  },
  extraReducers: (builder) => {
    builder.addCase(fetchComments.fulfilled, (state, action) => {
      state.comments = action.payload;
    });
  },
});

export default CommentSlice.reducer;
export const { editCommentLocal } = CommentSlice.actions;
