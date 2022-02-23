import { IPresent } from "../../../../App";

interface IPresentItem {
  item: IPresent;
}

const PresentItem = ({ item }: IPresentItem) => {
  return (
    <div>
      {item.value} {item.content}
    </div>
  );
};

export default PresentItem;
