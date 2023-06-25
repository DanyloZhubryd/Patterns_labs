import React, { useState } from "react";
import { useAppSelector } from "../store/store";
import { Button, Col, Modal, ModalBody, ModalHeader, Row } from "reactstrap";
import Image from "next/image";
import { TComment } from "../store/features/commentSlice";
import EditCommentsModal from "./editCommentsModal";

type TProps = {
  isOpen: boolean;
  onClose: () => void;
};

const CommentsModal = (props: TProps) => {
  const comments = useAppSelector((state) => state.comment.comments);
  const users = useAppSelector((state) => state.user.users);
  const [editModal, setEditModal] = useState<boolean>();
  const [editComment, setEditComment] = useState<TComment>({
    id: 0,
    text: "",
    userId: 0,
    storyId: 0,
  });

  return (
    <Modal isOpen={props.isOpen} toggle={() => props.onClose()}>
      <ModalHeader toggle={() => props.onClose()}>Comments</ModalHeader>
      <ModalBody>
        {comments.length === 0 && <Row className="m-2">No comments yet</Row>}
        {comments.map((val) => (
          <>
            <form>
              <Row className="m-2">
                <Col sm={1}>
                  <Image
                    src={"/media/userEmpty.jpg"}
                    alt="usr"
                    width={25}
                    height={25}
                    style={{ borderRadius: "50px" }}
                  />
                </Col>
                <Col>
                  <span className="fw-bold">
                    {users.find((user) => user.id === val.userId)?.username}
                  </span>
                </Col>
              </Row>
              <Row className="m-2" key={val.id}>
                {val.text}
              </Row>
              <Row>
                <Button
                  onClick={() => {
                    setEditModal(true);
                    setEditComment(val);
                  }}
                >
                  Edit
                </Button>
              </Row>
            </form>
          </>
        ))}
      </ModalBody>
      {editModal && (
        <EditCommentsModal
          isOpen={editModal}
          onClose={() => setEditModal(false)}
          comment={editComment}
        />
      )}
    </Modal>
  );
};

export default CommentsModal;
