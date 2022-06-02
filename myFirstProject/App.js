import React from 'react';
import {
  SafeAreaView,
  View,
  TextInput,
  TouchableOpacity,
  Text,
  Linking
} from 'react-native';
import QRCode from 'react-native-qrcode-svg';
import QRCodeScanner from 'react-native-qrcode-scanner';
import { RNCamera } from 'react-native-camera';
export default class App extends React.Component {
  constructor() {
    this.state = {
      text: '',
      scan: false,
    };
  }
  scanner = e => {
    Linking.openURL(e.data);
  };
  render() {
    return (
      <SafeAreaView>
        <View style={{flex: 1, justifyContent: 'center', alignItems: 'center'}}>
          <TouchableOpacity
            onPress={() => this.setState({scan: !this.state.scan})}
            style={{
              marginBottom: 10,
              padding: 10,
              borderRadius: 5,
              backgroundColor: 'Blue',
            }}>
            <Text style={{color: 'white'}}>Tara</Text>
          </TouchableOpacity>
          {this.state.scan && (
            <QrCodeScanner
              flashMode={RNCamera.Constants.FlashMode.torch}
              onRead={this.scanner}></QrCodeScanner>
          )}
          <Textinput
            onChangeText={text => this.setState(text)}
            value={this.state.text}
            style={{
              padding: 10,
              borderWidth: 1,
              borderColor: '#ddd',
              width: 300,
              marginBottom: 20,
              borderRadius: 5,
            }}
          />
          {this.state.text != '' && (
            <QRCode
              size={150}
              color={'red'}
              enableLinearGradient={true}
              backgroundColor={'blue'}
              linearGradient={['#000', 'red', 'green']}
              value={this.state.text}
            />
          )}
        </View>
      </SafeAreaView>
    );
  }
}
