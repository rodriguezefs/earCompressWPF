#!/bin/bash
FILES=/Users/ER/source/*

for file in $FILES
do
  echo $(basename $file)
done
