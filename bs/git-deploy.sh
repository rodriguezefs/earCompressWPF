#!/bin/bash
read -r -p 'Commit message:' desc # prompt user fomr commit message
git add .                         # track all files
git commit -m "$desc"             # commit with message

# push to origin
git push --repo https://rodriguezefs:2dn0GVWPIuIm@github.com/rodriguezefs/earCompressWPF.git            