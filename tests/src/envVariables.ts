export async function getEnvironmentVariables(): Promise<Record<string, string>> {
  // Simulamos un retraso para imitar una operación asíncrona
  await new Promise(resolve => setTimeout(resolve, 100));

  // En un entorno real, esto sería process.env
  // Aquí, simulamos algunas variables de entorno
  return {
    'NODE_ENV': 'development',
    'PATH': '/usr/local/bin:/usr/bin:/bin',
    'HOME': '/home/user',
    'USER': 'testuser',
    'LANG': 'es_ES.UTF-8'
  };
}

export async function formatEnvironmentVariables(variables: Record<string, string>): Promise<string> {
  let result = "<h1>Variables de Entorno</h1>";
  
  for (const [key, value] of Object.entries(variables)) {
    result += `<p><strong>${key}:</strong> ${value || "<vacio>"}</p>`;
  }

  return result;
}
