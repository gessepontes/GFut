import PropTypes from 'prop-types';
import NumberFormat from 'react-number-format';
import Input from '@material-ui/core/Input';
import InputLabel from '@material-ui/core/InputLabel';
import FormControl from '@material-ui/core/FormControl';

import React, { useRef, useEffect } from 'react';
import { useField } from '@unform/core';

function NumberFormatCustom(props) {
  const { inputRef, onChange, ...other } = props;

  return (
    <NumberFormat
      {...other}
      getInputRef={inputRef}
      onValueChange={(values) => {
        onChange({
          target: {
            name: props.name,
            value: values.value,
          },
        });
      }}
      thousandSeparator
      isNumericString
      //prefix="R$"
    />
  );
}

NumberFormatCustom.propTypes = {
  inputRef: PropTypes.func.isRequired,
  name: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
};

export default function InputMask({ name,label, ...rest }) {
  const inputRef = useRef(null);
  const { fieldName, registerField, defaultValue } = useField(name);
 
  useEffect(() => {
    registerField({
      name: fieldName,
      ref: inputRef.current,
      path: 'value',
      setValue(ref, value) {
        ref.setInputValue(value);
      },
      clearValue(ref) {
        ref.setInputValue('');
      },
    });
  }, [fieldName, registerField]);

  return (
      <FormControl fullWidth style={{ marginTop: 8 }} required>
        <InputLabel htmlFor={label}>{label}</InputLabel>
        <Input
          defaultValue={defaultValue}
          fullWidth
          margin="dense"
          error={false}      
          inputRef={inputRef}
          id={fieldName}
          label={label}
          inputComponent={NumberFormatCustom}             
          {...rest}     
        />
      </FormControl>
  );
}
