import http from "../http-common";
import { PayloadAction, createAsyncThunk, createSlice } from "@reduxjs/toolkit";

export type TStory = {
  id: number;
  caption: string;
  mediaUrl: string;
  userId: number;
};

interface TStoryState {
  stories: TStory[];
}

const initialState: TStoryState = {
  stories: [],
};

export const fetchStories = createAsyncThunk(
  "stories/fetch",
  async (thunkAPI) => {
    const response = await http.get<Array<TStory>>(`/Story`);
    const data = response.data;
    return data;
  }
);

export const deleteStorie = createAsyncThunk(
  "stories/delete",
  async (id: number) => {
    await http.delete(`/Story/${id}`);
  }
);

export const createStory = createAsyncThunk(
  "stories/create",
  async (story: Omit<TStory, "id">) => {
    await http.post(`/user/${story.userId}/story`, story);
  }
);

export const StorySlice = createSlice({
  name: "story",
  initialState,
  reducers: {
    deleteStory: (state, action: PayloadAction<TStory>) => {
      state.stories.splice(
        state.stories.findIndex((val) => val.id === action.payload.id),
        1
      );
    },
  },
  extraReducers: (builder) => {
    builder.addCase(fetchStories.fulfilled, (state, action) => {
      state.stories = action.payload;
    });
  },
});

export default StorySlice.reducer;
export const { deleteStory } = StorySlice.actions;
