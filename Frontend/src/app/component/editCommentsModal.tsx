import React, { useState } from "react";
import { useAppDispatch, useAppSelector } from "../store/store";
import { Button, Col, Modal, ModalBody, ModalHeader, Row } from "reactstrap";
import Image from "next/image";
import {
  TComment,
  editComment,
  editCommentLocal,
} from "../store/features/commentSlice";
import { useFormik } from "formik";

type TProps = {
  isOpen: boolean;
  onClose: () => void;
  comment: TComment;
};

const EditCommentsModal = (props: TProps) => {
  const users = useAppSelector((state) => state.user.users);
  const dispatch = useAppDispatch();

  const formik = useFormik<Omit<TComment, "id">>({
    initialValues: {
      ...props.comment,
    },
    onSubmit: async (values) => {
      await dispatch(editComment({ ...values, id: props.comment.id }));
      dispatch(editCommentLocal({ ...values, id: props.comment.id }));
      props.onClose();
    },
  });
  return (
    <Modal isOpen={props.isOpen} toggle={() => props.onClose()}>
      <ModalHeader toggle={() => props.onClose()}>Comments</ModalHeader>
      <ModalBody>
        <>
          <form onSubmit={formik.handleSubmit}>
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
                  {
                    users.find((user) => user.id === props.comment.userId)
                      ?.username
                  }
                </span>
              </Col>
            </Row>
            <Row className="m-2" key={props.comment.id}>
              <textarea
                style={{ height: "300px" }}
                name="text"
                onChange={formik.handleChange}
                value={formik.values.text}
              ></textarea>
            </Row>
            <Button type="submit">Submit</Button>
          </form>
        </>
      </ModalBody>
    </Modal>
  );
};

export default EditCommentsModal;
