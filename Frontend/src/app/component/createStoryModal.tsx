import React from "react";
import { useAppDispatch, useAppSelector } from "../store/store";
import { Button, Modal, ModalBody, ModalHeader, Row } from "reactstrap";
import { useFormik } from "formik";
import {
  TStory,
  createStory,
  fetchStories,
} from "../store/features/storySlice";

type TProps = {
  isOpen: boolean;
  onClose: () => void;
};

const CreateCommentsModal = (props: TProps) => {
  const users = useAppSelector((state) => state.user.users);
  const dispatch = useAppDispatch();

  const formik = useFormik<TStory>({
    initialValues: {
      id: 0,
      caption: "",
      mediaUrl: "",
      userId: 0,
    },
    onSubmit: async (values) => {
      await dispatch(createStory(values));
      await dispatch(fetchStories());
      props.onClose();
    },
  });
  return (
    <Modal isOpen={props.isOpen} toggle={() => props.onClose()}>
      <ModalHeader toggle={() => props.onClose()}>Create story</ModalHeader>
      <ModalBody>
        <>
          <form onSubmit={formik.handleSubmit}>
            <Row className="m-2">
              <select
                name="mediaUrl"
                onChange={formik.handleChange}
                value={formik.values.mediaUrl}
              >
                <option value={"media/image1.png"}>media/image1.png</option>
                <option value={"media/image2.png"}>media/image2.png</option>
              </select>
            </Row>
            <Row className="m-2">
              <select
                name="userId"
                onChange={formik.handleChange}
                value={formik.values.userId}
              >
                {users.map((val) => {
                  return (
                    <option key={val.id} value={val.id}>
                      {val.username}
                    </option>
                  );
                })}
              </select>
            </Row>
            <Row className="m-2">
              <textarea
                style={{ height: "300px" }}
                name="caption"
                onChange={formik.handleChange}
                value={formik.values.caption}
              ></textarea>
            </Row>
            <Button type="submit">Submit</Button>
          </form>
        </>
      </ModalBody>
    </Modal>
  );
};

export default CreateCommentsModal;
