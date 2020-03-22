import React, { useRef, useEffect } from "react";
import { useField } from "@rocketseat/unform";
import { TextField } from "@material-ui/core";

function MTextField({ name, apiError, ...rest }) {
  const ref = useRef(null);
  const { fieldName, registerField, defaultValue, error } = useField(name);

  useEffect(() => {
    if (ref.current) {
      registerField({
        name: fieldName,
        ref: ref.current,
        path: "value"
      });
    }
  }, [ref.current, fieldName]); // eslint-disable-line

  return (
    <TextField
      defaultValue={defaultValue}
      fullWidth
      margin="dense"
      error={false}
      helperText={error || apiError}
      inputRef={ref}
      name={fieldName}
      {...rest}
    />
  );
}


export default MTextField;