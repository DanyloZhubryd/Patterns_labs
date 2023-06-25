"use client";
import { useAppDispatch, useAppSelector } from "./store/store";
import { useEffect, useState } from "react";
import {
  TStory,
  deleteStorie,
  deleteStory,
  fetchStories,
} from "./store/features/storySlice";
import {
  Button,
  Card,
  CardBody,
  CardImg,
  CardText,
  Col,
  Input,
  Row,
} from "reactstrap";
import CommentsModal from "./component/commentsModal";
import { fetchComments } from "./store/features/commentSlice";
import { fetchUsers } from "./store/features/userSlice";
import CreateCommentsModal from "./component/createStoryModal";

export default function Home() {
  const dispatch = useAppDispatch();
  const [displayCount, setDisplayCount] = useState<number>(10);
  const [displayComments, setDisplayComments] = useState<boolean>(false);
  const [createModal, setCreateModal] = useState<boolean>(false);

  useEffect(() => {
    dispatch(fetchStories());
    dispatch(fetchUsers());
  }, [dispatch]);
  const stories = useAppSelector((state) => state.story.stories);
  return (
    <>
      <div style={{ display: "flex", flexDirection: "column" }}>
        <Button onClick={() => setCreateModal(true)}>Add</Button>
        {stories.slice(0, displayCount).map((val) => (
          <div
            key={val.id}
            style={{ margin: "auto", width: "30%", marginTop: "10px" }}
          >
            <Card style={{ width: "100%" }}>
              <CardImg
                top
                width="100%"
                src={val.mediaUrl}
                alt="Card image cap"
              />
              <CardBody style={{ display: "flex", flexDirection: "column" }}>
                <CardText>{val.caption}</CardText>

                <Row>
                  <Col className="d-flex">
                    <Button
                      style={{ margin: "auto" }}
                      onClick={() => {
                        setDisplayComments(true);
                        dispatch(fetchComments(val.id));
                      }}
                    >
                      Comments
                    </Button>
                  </Col>
                  <Col className="d-flex">
                    <Button
                      style={{ margin: "auto" }}
                      onClick={async () => {
                        await dispatch(deleteStorie(val.id));
                        dispatch(deleteStory(val));
                      }}
                    >
                      Delete
                    </Button>
                  </Col>
                </Row>
              </CardBody>
            </Card>
          </div>
        ))}
        <Button
          onClick={() => setDisplayCount((state) => state + 10)}
          style={{ width: "10%", margin: "auto", marginTop: "20px" }}
        >
          Show more
        </Button>
      </div>
      {displayComments && (
        <CommentsModal
          isOpen={displayComments}
          onClose={() => setDisplayComments(false)}
        />
      )}
      {createModal && (
        <CreateCommentsModal
          isOpen={createModal}
          onClose={() => setCreateModal(false)}
        />
      )}
    </>
  );
}
