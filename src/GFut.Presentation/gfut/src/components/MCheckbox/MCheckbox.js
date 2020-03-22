import React, { useRef, useEffect } from "react";
import { useField } from "@rocketseat/unform";
import { Checkbox, FormControlLabel  } from "@material-ui/core";

function MCheckbox({ name, label, apiError, ...rest }) {
  const ref = useRef(null);
  const { fieldName, registerField } = useField(name);

  useEffect(() => {
    if (ref.current) {
      registerField({
        name: fieldName,
        ref: ref.current,
        path: "checked"
      });
    }
  }, [ref.current, fieldName]); // eslint-disable-line

  return (
    <FormControlLabel
      control={
        <Checkbox
          color="primary"
          checked={ref.checked}
          inputRef={ref}
          {...rest}
        />
      }
      label={label}
   />    
  );
}


export default MCheckbox;