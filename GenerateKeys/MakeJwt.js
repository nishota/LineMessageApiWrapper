// NOTE: jwkとチャンネル情報からjwtを生成する
// NOTE: C#上でこの処理は行えるため、このコードは実質不要。

const jose = require('node-jose');

const privateKey = JSON.parse(`
{
    "key_ops": [
      "sign"
    ],
    "ext": true,
    "kty": "RSA",
    "n": "xVFkJu7fNkJMq9Nsj63hWpEPEuYYdbHh_fTfqzML-UGVUlTHzZV0D7QFdntIKQQ0B3iHpav5hHEFD-VoXDFTlJoOsiiqoAP3ldLULkz0hQjJt7zRuRc7VxbuEG1bpaxM6qsrfINZ7A3IRxe1KeAftl6yncOGN5ZobLOqdOVSuL01pf_46M5MV2U-yMrZaZxAygrmHeZoFOx-EIFH73yNc_BVonvJGGZZ7DXRx5VSy62S8WoMoyxUAHRVdaGX1pQuoaLxuSdUWzOzH1XA8s-WOPXhPo-W1oZMDR09YF7OOjseTlQzW_vd44pyKoP4nlBbrQnckUApqXeskRVtZ-v20w",
    "e": "AQAB",
    "d": "JMq0Xf4UaM2b9j4J9BB8AKMjqGZ3ERsGBJBwVD_Eb8mmyh880jyX04XBrwH1xpAeE3aJ9H5InEVmqDwiZW5dI0xGiTnD9upGdA1HuwpmXZfx5Oy0PkryqZ6A7Vc2y4GBJhCcny7uyXEYcwkcop5Dy4GE1J3snNjSx9IIapuH_SIW1hdCGBS_Old49bT8EiopksaeIrkxufUSc7rdyXDhPr-G4gxpLHhmr7Ja8WYGWhM3MYzUtPJ5pxPDSYujj3We9KUML3Zys1U0naQPnX2MhDfgJo8LkVGMJyGh30DWSYUAIbl8shQN-8S8_LH9l1Xd7fVGkKQ5BFKu_-iDxYexAQ",
    "p": "5RZqd-9tvgoPi5HhgiabCHYb_wE6Fz7ewCl_Bs1eHa9OgDipRPAFOFI_AoZCICRf7pLsygyDDlO4kTZECv6qG9r1rEAUtIQMi01GD2nF5zE3R2lXb13SIgCELJoSfS7G_fRtXZiN5417HhHtdsquQTGAuabQ5Mg4iPsJkZVbhuE",
    "q": "3H-I7izvx434Mno-W42fA-9fbFI7xFOF5fDJErQJmUFjyibMqq-YSZIQuzubRMBo2Xr60xnnkA3TGLAC28yTtjd3tSnpxRfDL84xRRHFLfId3tSmTYH7XGWjBC-96cHlDNppl21wI8IEa0cd4BISyLNHAnI2FbDRdn2r6vJrGDM",
    "dp": "WtiBzh_3kAYjVgC6wccXccqMnZpZ8__ti5ypEAR-zxzG75gIoBripwwOiqy9KkvicxR2rEU774GJzqQLZaTJxpQVGoKq807uPoudPd1_Kohc2IfQsYwuGWfFAn7y2Aulw-2bNSObGnkDmtAXMCV95sJ_vp-FdURlDwUmLUJicmE",
    "dq": "P9nmqyH0JZNlBikEGbr_C0KsHVAK4qVVJur9Lx9XkDuxS_7EUcEblmJn2fA-3D_jnObR74OW3M5EDOgbS88ID0Isthd3DI3_Bb7t4ZRtxwpPwBFQPy2evnjoJfQ1SJXPYFN3NFSKnrA2W2JyskpJijjwHTM5mjpjza5CtHySqqU",
    "qi": "JBFEP-3Uz30RGbKTEgdTUhliXJdO45g7PQjrRVlv6yxfSGlvimUsqJtE4ODeVAk7PYbnC_Vj-QtVWZrG6hxplM6yhSqQ3R8iBX7yfWYCmjvmKnJFfWZsU1MHQI4V0K9ZwC0wAtBlx0sM0HltGznV0XY4mRKyGA_JnbQl4xpi00o",
    "alg": "RS256"
  }
`);

const header = {
    alg: "RS256",
    typ: "JWT",
    kid: "ae102522-2f6d-4de2-9e69-3f78616ffadc"
};

const payload = {
    iss: "1657535572",
    sub: "1657535572",
    aud: "https://api.line.me/",
    exp: Math.floor(new Date().getTime() / 1000) + 60 * 30,
    token_exp: 60 * 60 * 24 * 30
};

jose.JWS.createSign({ format: 'compact', fields: header }, privateKey)
    .update(JSON.stringify(payload))
    .final()
    .then(result => {
        console.log(result);
    });