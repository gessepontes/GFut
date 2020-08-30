import React, { useRef, useEffect, useState } from "react";
import { useField } from '@unform/core';
import { Checkbox, FormControlLabel  } from "@material-ui/core";

function MCheckbox({ name, label, apiError, ...rest }) {
  const inputRefs = useRef(null);
  const { fieldName, registerField, defaultValue} = useField(name);

  useEffect(() => {
    if(inputRefs.current){
      registerField({
        name: fieldName,
        ref: inputRefs.current,
        path: "checked"
      });
    }
  }, [fieldName, registerField]); // eslint-disable-line

  const [state, setState] = useState(defaultValue);

  return (
    <div>
    <FormControlLabel
      control={
        <Checkbox
          id={fieldName}
          name={fieldName}
          color="primary"
          checked={state}
          onChange={() => setState(!state)}
          inputRef={ref => {
            inputRefs.current = ref;
          }}
          {...rest}
        />
      }
      label={label}
   /> 
   </div>   
  );
}


export default MCheckbox;