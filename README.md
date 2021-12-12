# aup2exo

[AviUtl](http://spring-fragrance.mints.ne.jp/aviutl/)
プロジェクトファイルから拡張編集のオブジェクトファイル (*.exo) を出力するコンソールアプリです。

## 使い方

### コンソールを開かない場合

AviUtl プロジェクトファイル (*.aup) を `aup2exo.exe` にドラッグ&ドロップしてください。
プロジェクトファイルと同じ場所に `<元のファイル名>_<シーン番号>.exo` が出力されます。

### コンソールから使う場合

```
aup2exo 0.0.0
Copyright © 2021 karoterra

  -o, --out            出力するexoファイルのパス

  -s, --scene          出力するシーンの番号(Rootなら0)

  --help               Display this help screen.

  --version            Display version information.

  Filename (pos. 0)    Required. aupファイルのパス
```

## 設定

フィルタプラグインによって追加されたフィルタオブジェクトの情報を出力するためには、 `setting.json` にフィルタオブジェクトの情報を保存しておく必要があります。
書式は以下の通りです。
```json
[
    {
        "name": "フィルタ名",
        "trackbars": [
            "トラックバー名1",
            "トラックバー名2"
        ],
        "checkboxes": [
            "チェックボックス名1",
            "チェックボックス名2"
        ]
    }
]
```

サンプルとして [PSDToolKit](https://github.com/oov/aviutl_psdtoolkit)
に同梱されている `チャンネルストリップ` と `Aux1 チャンネルストリップ`
についてあらかじめ記載してあるので、必要に応じて各自で追記してください。

## ライセンス
このソフトウェアは MIT ライセンスのもとで公開されます。
詳細は [LICENSE](LICENSE) を参照してください。

使用したライブラリ等については [CREDITS](CREDITS.md) を参照してください。
