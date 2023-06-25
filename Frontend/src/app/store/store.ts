import { configureStore } from "@reduxjs/toolkit";
import { StorySlice } from "./features/storySlice";
import { TypedUseSelectorHook, useDispatch, useSelector } from "react-redux";
import { CommentSlice } from "./features/commentSlice";
import { UserSlice } from "./features/userSlice";

export const store = configureStore({
  reducer: {
    story: StorySlice.reducer,
    comment: CommentSlice.reducer,
    user: UserSlice.reducer,
  },
});

export const useAppDispatch: () => typeof store.dispatch = useDispatch;
export const useAppSelector: TypedUseSelectorHook<
  ReturnType<typeof store.getState>
> = useSelector;
