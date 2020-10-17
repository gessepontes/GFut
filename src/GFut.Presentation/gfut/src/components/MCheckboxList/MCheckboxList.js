import React, { useEffect, useRef } from 'react';
import { useField } from '@unform/core';
import { Checkbox, FormControlLabel  } from "@material-ui/core";

import FormControl from '@material-ui/core/FormControl';
import FormGroup from '@material-ui/core/FormGroup';

function MCheckboxList({ name, options, ...rest }) {
  const inputRefs = useRef([]);
  const { fieldName, registerField, defaultValue = [] } = useField(name);

  useEffect(() => {
    registerField({
      name: fieldName,
      ref: inputRefs.current,
      getValue: (refs) => {
        return refs.filter(ref => ref.checked).map(ref => ref.value);
      },
      clearValue: (refs) => {
        refs.forEach(ref => {
          ref.checked = false;
        });
      },
      setValue: (refs, values) => {
        refs.forEach(ref => {
          if (values.includes(ref.id)) {
            ref.checked = true;
          }
        });
      },
    });
  }, [defaultValue, fieldName, registerField]);

  return (
    <div>
      <FormControl component="fieldset">
        <FormGroup>
          {options.map((option, index) => (
              <FormControlLabel  key = {index}
              control={
                <Checkbox
                  key = {index}
                  id={option.id}
                  name={fieldName}
                  color="primary"
                  checked={defaultValue.find((dv) => dv === option.id)}
                  inputRef={ref => {
                          inputRefs.current[index] = ref;
                        }}
                  value={option.value}       
                  {...rest}
                />
              }
              label={option.label}
            /> 
            ))}
        </FormGroup>
      </FormControl>
    </div>
  );
};

export default MCheckboxList;