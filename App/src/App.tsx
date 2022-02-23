import React, { useEffect, useState } from "react";
import "./App.css";
import ChristmasTree from "./components/ChristmasTree/ChristmasTree";

export interface IPresent {
  value: number;
  content: string;
}

export const PresentContext = React.createContext<IPresent[]>([]);

function App() {
  const [presents, setPresents] = useState<IPresent[]>([]);

  const handlePresents = () => {
    const presents: IPresent[] = [
      {
        value: 5,
        content: "test",
      },
      {
        value: 25,
        content: "test2",
      },
      {
        value: 50,
        content: "test3",
      },
    ];
    setPresents(presents);
  };

  useEffect(() => {
    handlePresents();
  }, []);

  if (!presents) {
    return <div>loading</div>;
  }

  return (
    <div>
      <PresentContext.Provider value={presents}>
        <ChristmasTree />
      </PresentContext.Provider>
    </div>
  );
}

export default App;
