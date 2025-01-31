namespace VteAppPx.scripts
{
    static class ScriptsJS
    {
        /**
         * Classe auxiliar que contem os scripts
         */

        static public string scriptIrPaginaCartoesEObterTabelaECpfs = @"
            (async function(window) {
                console.log('Iniciando o script...');

                var dados;

                window.chrome.webview.addEventListener('message', function (msg) {
                    console.log(msg.data);
                    data = JSON.parse(msg.data);
                });
        
                function getElement(xpath) {
                    return document.evaluate(xpath, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
                }

                function delay(time) {
                    return new Promise(resolve => setTimeout(resolve, time));
                }

                async function waitForElement(xpath, timeout = 10000) {
                    let startTime = Date.now();
                    let cpf = getElement(xpath);

                    while (!cpf) {
                        if (Date.now() - startTime > timeout) {
                            console.log('Timeout: CPF não encontrado');
                            return null;  
                        }
                        cpf = getElement(xpath);
                    }
    
                    return cpf;
                }

                console.log('Esperando 3 segundos...');
                await delay(2000);

                // clica no botão relatório
                getElement('/html/body/div[1]/section/div/main/div[2]/div[1]/div/div[2]/div/div[2]/div[2]/div/button[4]').click();
                
                console.log('Esperando 3 segundos...');
                await delay(3000);

                getElement('/html/body/div[1]/section/div/main/div[6]/div/div/div[2]/div/div[2]/div[1]/div/div[1]/button[2]').click();

                var tabelaSaldos = getElement('/html/body/div[1]/section/div/main/div[6]/div/div/div[2]/div/div[2]/div[1]/div/div[2]/div[2]/div/div[3]/table');
                
                window.chrome.webview.postMessage('saldos###' + tabelaSaldos.outerHTML);

                console.log('Esperando 5 segundos');
                await delay(5000);
                
                // No meneu lateral
                getElement('/html/body/div[1]/section/div/header/div[1]/button').click();

                await delay(1500);

                // Clica na opção do menu
                getElement('/html/body/div[1]/section/nav/div/nav/div[4]').click();

                await delay(1500);

                // Clica no op usuario
                getElement('/html/body/div[1]/section/nav/div/nav/div[5]/div[3]').click();

                await delay(1000);

                var inputElement = Object.getOwnPropertyDescriptor(window.HTMLInputElement.prototype, 'value').set;
                
                var input = getElement('/html/body/div[1]/section/div/main/div[8]/div/div[2]/div[2]/div[1]/div[2]/div[2]/div/input');

                var btnPesquisar = getElement('/html/body/div[1]/section/div/main/div[8]/div/div[2]/div[2]/div[1]/div[2]/div[2]/button[1]');

                for (let i = 0; i < data.length; i++) {
                    if (anterior === data[i].Usuário) continue;
                    
                    inputElement.call(input, data[i].Usuário);
                    input.dispatchEvent(new Event('input', { bubbles: true }));
                    input.dispatchEvent(new Event('change', { bubbles: true }));

                    btnPesquisar.click();

                    await delay(300);
                    
                    let cpf = await waitForElement('/html/body/div[1]/section/div/main/div[8]/div/div[2]/div[2]/div[1]/div[3]/div/table/tbody/tr/td[3]', 3000);
                    
                    if (cpf) {
                        window.chrome.webview.postMessage('cpf###'+cpf.textContent+'###'+data[i].Usuário);
                        var anterior = data[i].Usuário;
                        btnPesquisar.click();
                    } else {
                        var anterior = data[i].Usuário;
                        btnPesquisar.click();
                    }

                    await delay(300);
                }

                window.chrome.webview.postMessage('Fim###');
                
                getElement('/html/body/div[1]/section/div/header/div[2]/button').click();
                
                await delay(500);

                getElement('/html/body/div[1]/section/div/header/div[2]/div[2]/div/button[4]').click();

                console.log('Script concluído.');
            })(window);
            ";

        static public string scriptCapturarLogin = @"
                        console.log('Login');
                        document.body.addEventListener('click', function(event) {
                             if (event.target.tagName.toLowerCase() === 'button' && event.target.type === 'submit') {

                                let login = document.evaluate('/html/body/div[1]/div/div[1]/div/form/div[3]/input', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.value;

                                let senha = document.evaluate('/html/body/div[1]/div/div[1]/div/form/div[4]/div/input', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.value;
                                var res = 'login###'+login+'###'+senha
                                console.log('Dados capturados');
                                window.chrome.webview.postMessage(res);
                             }
                        });
                    ";
    }
}
