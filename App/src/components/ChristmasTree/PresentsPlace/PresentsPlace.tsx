import React from "react";
import { PresentContext } from "../../../App";
import PresentItem from "./PresentItem/PresentItem";

const PresentsPlace = () => {
  const presents = React.useContext(PresentContext);
  return (
    <div>
      <div>Presents place</div>
      {presents.map((item) => {
        return <PresentItem key={item.value} item={item} />;
      })}
    </div>
  );
};

export default PresentsPlace;
