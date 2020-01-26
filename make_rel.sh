VERSION='v0.0.1b3'
BIN_DIR='./.rel/'$VERSION
BIN_DIR_WITH_CHROME='./.rel/'$VERSION'-with-chrome'
REL_DIR='./Vt.Client.App/bin/Release'
DEB_DIR='./Vt.Client.App/bin/Debug'

# 清空已有的文件
rm -rf $BIN_DIR_WITH_CHROME
rm -rf $BIN_DIR

############################################################
# 创建带chrome版本
############################################################

# copy binary files
mkdir $BIN_DIR
cp -r $DEB_DIR/external/* $REL_DIR/external/
cp -rf $REL_DIR/*  $BIN_DIR/

cd $BIN_DIR

# ./login
mkdir ./login
rm -f ./login/bilibili.json
touch ./login/bilibili.json

#./config
mkdir ./config
cp -r ../../rel_helper/config/* ./config
rm -f ./config/app.cfg 
cp ../../rel_helper/app_with_chrome.cfg ./config/app.cfg

# remove pdb files
rm -f ./*.pdb

# remove log files
rm -rf ./log

############################################################
cd -
mv $BIN_DIR $BIN_DIR_WITH_CHROME
cp -rf $BIN_DIR_WITH_CHROME $BIN_DIR

cd -
rm -rf ./external/Chrome
rm -rf ./config/*
cp -r ../../rel_helper/config/* ./config

cd -
zip -r $BIN_DIR_WITH_CHROME.zip $BIN_DIR_WITH_CHROME
zip -r $BIN_DIR.zip $BIN_DIR