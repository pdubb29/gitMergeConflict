This tool is used to execute all the commands necessary to fix a pull request merge.
A lot of the times you will find yourself executing these commands over and over in your git repositories:

```
git status
git checkout master
git pull
git checkout {oldBranch}
git merge master
git mergetool
```

All those commands will now be done in one command, (after you have edited your path variable)
```
gmc
```