VERSION='v0.0.1b'
BIN_DIR='./.rel/'$VERSION
REL_DIR='./Vt.Client.App/bin/Release'
DEB_DIR='./Vt.Client.App/bin/Debug'

# copy binary files
mkdir $BIN_DIR
cp -r ./Vt.Client.App/bin/Release/* ./.rel/$VERSION
cd $BIN_DIR

# ./external
cp -r $DEB_DIR/external/* BIN_DIR/external/

# ./login
mkdir ./login
touch ./login/bilibili.json

#./config
mkdir ./config
cp -r ../../rel_helper/config/* ./config

# remove pdb files
rm -f ./*.pdb

# remove log files
rm -rf ./log