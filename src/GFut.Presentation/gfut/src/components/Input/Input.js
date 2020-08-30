import React, { useRef, useEffect } from 'react';
import { useField } from '@unform/core';
import { TextField  } from "@material-ui/core";

export default function Input({ name, label, ...rest }) {
 
  const inputRef = useRef(null);
  const { fieldName, defaultValue, registerField, error } = useField(name);

  useEffect(() => {
    registerField({
      name: fieldName,
      ref: inputRef.current,
      path: 'value',
    });
  }, [fieldName, registerField]);

  return (
    <TextField
      defaultValue={defaultValue}
      fullWidth
      margin="dense"
      error={false}
      helperText={error}
      inputRef={inputRef}
      id={fieldName}
      label={label}
      {...rest}
    />
  );
} 


